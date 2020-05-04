using Castle.Core.Logging;
using Castle.Windsor;
using LearningExperience.Repository.Interfaces;
using LearningExperience.Repository.MongoDB;
using LearningExperience.Models;
using LearningExperience.Utils;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace LearningExperience.Repository.MongoDB
{
    public class SimpleRepository<T> : MongoDBBaseRepository, ISimpleRepository<T> where T : ISimpleModel
    {

        protected void TranslateExceptions(Action action)
        {
            try
            {
                action();
            }
            catch (MongoDuplicateKeyException ex)
            {
                throw new InvalidOperationException("Chave duplicada: ", ex);
            }
        }
        public object GetByIdAsDocument(string id)
        {
            var mongoQuery = Query<T>.EQ(u => u.Id, id);

            return BaseCollection.FindOneAs<BsonDocument>(mongoQuery);
        }

        public bool Exists(string id)
        {
            var mongoQuery = Query<T>.EQ(u => u.Id, id);

            return BaseCollection.Count(mongoQuery) > 0;
        }

        public SimpleRepository(IWindsorContainer container)
        {
        }

        protected virtual string GetCollectionName()
        {
            var collectionName = typeof(T).Name + "s";
            collectionName = collectionName.Replace("ys", "ies");
            if (collectionName.EndsWith("chs"))
            {
                collectionName = collectionName.Substring(0, collectionName.Length - 3) + "ches";
            }
            return collectionName;
        }

        protected MongoCollection<T> BaseCollection
        {
            get
            {
                var collectionName = GetCollectionName();
                return database.GetCollection<T>(collectionName);
            }
        }

        public void BulkInsert(IEnumerable<T> items, int batchSize, Action<BulkInsertResult> batchAction)
        {
            try
            {
                var bulkOperation = BaseCollection.InitializeOrderedBulkOperation();
                var i = 0;
                foreach (var doc in items)
                {
                    if (doc == null)
                        continue;
                    if (string.IsNullOrWhiteSpace(doc.Id))
                        doc.Id = CombGenerator.GenerateComb().ToString();
                    bulkOperation.Insert(doc);
                    i++;
                    if (i % batchSize == 0)
                    {
                        var bulkWriteResult = bulkOperation.Execute();
                        batchAction?.Invoke(new BulkInsertResult { Count = bulkWriteResult.InsertedCount });
                        bulkOperation = BaseCollection.InitializeOrderedBulkOperation();
                        i = 0;
                    }
                }
                if (i > 0)
                {
                    var bulkWriteResult = bulkOperation.Execute();
                    batchAction?.Invoke(new BulkInsertResult { Count = bulkWriteResult.InsertedCount });
                }
            }
            catch (Exception e)
            {
                throw new InvalidOperationException($"Error performing bulk insert: {e}");
            }
        }

        public T GetById(string id)
        {
            var mongoQuery = Query<T>.EQ(u => u.Id, id);
            return BaseCollection.FindOne(mongoQuery);
        }

        public T GetByName(string name)
        {
            return BaseCollection.FindOne(Query<T>.EQ(u => u.Name, name));
        }

        public string GetDataBaseName()
        {
            return BaseCollection.Database.Name;
        }

        protected virtual void InitializeFields(T t)
        {

        }

        public virtual T Create(T t)
        {
            InitializeFields(t);
            var retry = 0;
            do
            {
                try
                {
                    t.Id = CombGenerator.GenerateComb().ToString();
                    BaseCollection.Insert(t);
                    break;
                }
                catch (MongoDuplicateKeyException e)
                {
                    retry++;
                    if (retry > 3)
                        throw new InvalidOperationException($"Maximum of {retry} retries exceeded while creating {typeof(T).Name}: {e}");
                }
            } while (true);

            return t;
        }


        public virtual T CreateWithId(T t)
        {
            TranslateExceptions(() =>
            {
                InitializeFields(t);
                if (string.IsNullOrEmpty(t.Id))
                    t.Id = CombGenerator.GenerateComb().ToString();
                BaseCollection.Insert(t);
            });
            return t;
        }
        public void Delete(T t)
        {
            BaseCollection.Remove(Query<T>.EQ(u => u.Id, t.Id));
        }

        public void Delete(string id)
        {
            BaseCollection.Remove(Query<T>.EQ(u => u.Id, id));
        }

        public void SoftDelete(T t)
        {
            t.Deleted = true;

            TranslateExceptions(() => { BaseCollection.Save(t); });
        }


        public virtual void Update(T t)
        {
            TranslateExceptions(() => { BaseCollection.Save(t); });
        }

        public T FindOne(string fieldName, object fieldValue)
        {
            return BaseCollection.FindOne(Query.EQ(fieldName, BsonValue.Create(fieldValue)));
        }

        public T FindOne(IDictionary<string, object> fieldValues)
        {
            return BaseCollection.FindOne(new QueryDocument(fieldValues));
        }

        public IList<T> FindAll(string fieldName, object fieldValue)
        {
            return BaseCollection.Find(Query.EQ(fieldName, BsonValue.Create(fieldValue))).ToList();
        }

        public IList<T> GetAll()
        {
            return BaseCollection.Find(Query<T>.NE(x => x.Deleted, true)).OrderBy(t => t.Name).ToList();
        }

        public long Count()
        {
            return BaseCollection.Count();
        }

        public void AddToArray(string id, string attributeName, object attributeValue)
        {
            UpdateBuilder updateBuilder = new UpdateBuilder();
            updateBuilder.PushWrapped(attributeName, attributeValue);
            BaseCollection.Update(Query<T>.EQ(a => a.Id, id), updateBuilder);
        }


        public virtual T UpdateSpecificAttribute(string id, string attributeName, object attributeValue)
        {
            UpdateBuilder ub = new UpdateBuilder();
            if (attributeValue == null)
                ub.Set(attributeName, BsonNull.Value);
            else
                ub.Set(attributeName, BsonValue.Create(attributeValue));
            BaseCollection.Update(Query<T>.EQ(a => a.Id, id), ub);
            return BaseCollection.FindOneById(id);
        }

        public virtual T UpdateSpecificAttribute(string id, Expression<Func<T, object>> memberExpression, object value)
        {
            UpdateBuilder<T> ub = new UpdateBuilder<T>();
            ub.Set(memberExpression, value);
            BaseCollection.Update(Query<T>.EQ(t => t.Id, id), ub);
            return BaseCollection.FindOneById(id);
        }

        public void Increment<TMember>(Expression<Func<T, TMember>> filterExpression, TMember value, Expression<Func<T, long>> memberExpression, long amount)
        {
            var now = Utils.Helpers.BrazilTime();
            UpdateBuilder<T> ub = new UpdateBuilder<T>();
            ub.Inc(memberExpression, amount);
            BaseCollection.Update(Query<T>.EQ(filterExpression, value), ub);
        }

        public IList<string> GetAllIds()
        {
            IList<string> result = new List<string>();
            ForEach((a) => result.Add(a.Id));
            return result;
        }

        public void CreateOrUpdate(T t)
        {
            TranslateExceptions(() => { BaseCollection.Save(t); });
        }



        public T GetByPropertyName(string propertyName, object propertyValue)
        {
            return BaseCollection.FindOne(Query.EQ(propertyName, BsonValue.Create(propertyValue)));
        }

        public long Count(string query)
        {
            BsonDocument doc = BsonSerializer.Deserialize<BsonDocument>(query);
            var mongoQuery = new QueryDocument(doc);
            return BaseCollection.Count(mongoQuery);
        }

        public void ForEach(Action<T> itemAction)
        {
            MongoCursor<T> cursor = BaseCollection.FindAll().SetFlags(QueryFlags.NoCursorTimeout).SetSnapshot().SetSortOrder();
            try
            {
                foreach (T item in cursor)
                {
                    itemAction(item);
                }
            }
            finally
            {
                //exhaust
                cursor.Last();
            }
        }

        public bool ContainsProperty(string id, string propPath)
        {
            BsonDocument doc = (BsonDocument)GetByIdAsDocument(id); ;
            var props = propPath.Split('.');
            var curProp = 0;
            foreach (var prop in props)
            {
                if (!doc.Contains(prop))
                    return false;
                curProp++;
                if (curProp < props.Length)
                {
                    if (doc[prop] is BsonNull)
                        return false;
                    doc = doc[prop].AsBsonDocument;
                }

            }
            return true;
        }

        public long GetCount()
        {
            return BaseCollection.Count();
        }

        public T GetBy(Expression<Func<T, bool>> filter)
        {
            return Queryable.Where(BaseCollection.AsQueryable(), filter).FirstOrDefault();
        }

        public IList<T> ListBy(Expression<Func<T, bool>> filter)
        {
            return Queryable.Where(BaseCollection.AsQueryable(), filter).ToList();
        }
    }
}
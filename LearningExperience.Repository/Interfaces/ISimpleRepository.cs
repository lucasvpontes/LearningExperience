using LearningExperience.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace LearningExperience.Repository.Interfaces
{
    public interface ISimpleRepository<T> where T : ISimpleModel
    {
        T GetById(string id);
        void Increment<TMember>(Expression<Func<T, TMember>> filterExpression, TMember value, Expression<Func<T, long>> memberExpression, long amount);
        T GetByName(string name);
        T Create(T t);
        void Delete(T t);
        void SoftDelete(T t);
        void Delete(string id);
        void Update(T t);
        T FindOne(string fieldName, object fieldValue);
        T FindOne(IDictionary<string, object> fieldValues);
        IList<T> FindAll(string fieldName, object fieldValue);
        IList<T> GetAll();
        long Count();
        T UpdateSpecificAttribute(string id, string attributeName, object attributeValue);
        T UpdateSpecificAttribute(string id, Expression<Func<T, object>> memberExpression, object value);
        void ForEach(Action<T> itemAction);
        void AddToArray(string id, string attributeName, object attributeValue);
        IList<string> GetAllIds();
        void CreateOrUpdate(T t);
        T GetByPropertyName(string propertyName, object propertyValue);
        long Count(string query);
        T CreateWithId(T t);
        void BulkInsert(IEnumerable<T> items, int batchSize, Action<BulkInsertResult> batchAction);
        string GetDataBaseName();
        object GetByIdAsDocument(string id);
        bool ContainsProperty(string id, string propPath);
        bool Exists(string id);
        long GetCount();
        T GetBy(Expression<Func<T, bool>> filter);
        IList<T> ListBy(Expression<Func<T, bool>> filter);
    }

    public class BulkInsertResult
    {
        public long Count { get; set; }
    }

}
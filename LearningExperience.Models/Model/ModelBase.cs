using MongoDB.Bson.Serialization.Attributes;
using System;

namespace LearningExperience.Models
{
    [BsonIgnoreExtraElements]
    public class ModelBase: MarshalByRefObject, IModelRoot
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool Deleted { get; set; }
    }
}
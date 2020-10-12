using LearningExperience.Models.Enums;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace LearningExperience.Models.Model
{
    [BsonCollection("AsyncXRays")]
    [BsonIgnoreExtraElements]
    public class AsyncXRay: Document
    {
        public string UserId { get; set; }
        public AsyncAction Action { get; set; }
    }
}

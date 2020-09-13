using LearningExperience.Models.Enums;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace LearningExperience.Models.Model
{
    [BsonCollection("UsersProgress")]
    [BsonIgnoreExtraElements]
    public class UserProgress: Document
    {
        public GameLevelType Module { get; set; }
        public double Progress { get; set; }
        public string UserId { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}

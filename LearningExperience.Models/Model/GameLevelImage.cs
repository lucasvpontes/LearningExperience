using LearningExperience.Models.Enums;
using MongoDB.Bson.Serialization.Attributes;

namespace LearningExperience.Models.Model
{
    [BsonCollection("GameLevelImages")]
    [BsonIgnoreExtraElements]
    public class GameLevelImage: Document
    {
        public Module Module { get; set; }
        public string Path { get; set; }
    }
}

using LearningExperience.Models.Enums;
using MongoDB.Bson.Serialization.Attributes;

namespace LearningExperience.Models.Model
{
    [BsonCollection("GameLevelImages")]
    [BsonIgnoreExtraElements]
    public class GameLevelImage: Document
    {
        public GameLevelType GameLevelType { get; set; }
        public string Path { get; set; }
        public bool Match { get; set; }
        public string ExternalId { get; set; }
    }
}

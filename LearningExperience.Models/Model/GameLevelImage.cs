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
    }
}

using LearningExperience.Models.Enums;
using MongoDB.Bson.Serialization.Attributes;

namespace LearningExperience.Models.Model
{
    [BsonCollection("GameLevelImages")]
    [BsonIgnoreExtraElements]
    public class GameLevelImage: Document
    {
        public Module GameModule { get; set; }
        public string Urn { get; set; }
    }
}

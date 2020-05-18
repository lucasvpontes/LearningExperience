using MongoDB.Bson.Serialization.Attributes;

namespace LearningExperience.Models
{

    [BsonCollection("Advisors")]
    [BsonIgnoreExtraElements]
    public class Advisor : Document 
    {
        public string Profession { get; set; }
        public string Education { get; set; }
        public string Specialization { get; set; }
        public string? Comment { get; set; }
        public string? LastUpdate { get; set; }
    }
}

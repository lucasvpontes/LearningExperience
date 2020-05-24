using MongoDB.Bson.Serialization.Attributes;
using System;

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
        public DateTime? LastUpdate { get; set; }
    }
}

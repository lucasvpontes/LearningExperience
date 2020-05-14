using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace LearningExperience.Models
{
    
    [BsonCollection("Advisors")]
    [BsonIgnoreExtraElements]
    public class Advisor : Document 
    {
        [JsonProperty("profession")]
        public string Profession { get; set; }
        [JsonProperty("education")]
        public string Education { get; set; }
        [JsonProperty("specialization")]
        public string Specialization { get; set; }
        [JsonProperty("comment")]
        public string? Comment { get; set; }
        [JsonProperty("lastUpdate")]
        public string? LastUpdate { get; set; }
    }
}

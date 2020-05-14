using LearningExperience.Models.Enums;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;

namespace LearningExperience.Models
{
    
    [BsonCollection("Patients")]
    [BsonIgnoreExtraElements]
    public class Patient : Document 
    {
        [JsonProperty("diseaseLevel")]
        public DiseaseLevel DiseaseLevel { get; set; }
        [JsonProperty("age")]
        public int Age { get; set; }
        [JsonProperty("colorsIssue")]
        public ColorIssueStatus ColorsIssue { get; set; }
        [JsonProperty("favoriteObject")]
        public string? FavoriteObject { get; set; }
        [JsonProperty("favoriteJoke")]
        public string? FavoriteJoke { get; set; }
        [JsonProperty("favoritePastTime")]
        public string? FavoritePastTime { get; set; }
        [JsonProperty("comment")]
        public string? Comment { get; set; }
        [JsonProperty("lastUpdate")]
        public DateTime? LastUpdate { get; set; }
    }
}

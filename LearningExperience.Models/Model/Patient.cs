using LearningExperience.Models.Enums;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace LearningExperience.Models
{

    [BsonCollection("Patients")]
    [BsonIgnoreExtraElements]
    public class Patient : Document 
    {
        public DiseaseLevel DiseaseLevel { get; set; }
        public int Age { get; set; }
        public bool ColorsIssue { get; set; }
        public string? FavoriteObject { get; set; }
        public string? FavoriteJoke { get; set; }
        public string? FavoritePastTime { get; set; }
        public string? Observation { get; set; }
        public DateTime? LastUpdate { get; set; }
    }
}

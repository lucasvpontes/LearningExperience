using System;

namespace LearningExperience.Models
{

    public class Patient : ModelBase
    {
        public string DiseaseLevel { get; set; }
        public int Age { get; set; }
        public string? ColorsIssue { get; set; }
        public string? FavoriteObject { get; set; }
        public string? FavoriteJoke { get; set; }
        public string? FavoritePastTime { get; set; }
        public string? Comment { get; set; }
        public DateTime? LastUpdate { get; set; }
    }
}

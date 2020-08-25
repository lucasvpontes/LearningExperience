using LearningExperience.Domain.Patients;
using System;

namespace LearningExperience.Api.UseCases.GetPatientDetails
{
    public class GetPatientDetailsRequest
    {
        public string? Id { get; set;}
        public string Name { get; set; }
        public int Age { get; set; }
        public DiseaseLevel DiseaseLevel { get; set; }
        public bool ColorsIssue { get; set; }
        public string? FavoriteObject { get; set; }
        public string? FavoriteJoke { get; set; }
        public string? FavoritePastTime { get; set; }
        public string? Observation { get; set; }
        public DateTime? LastUpdate { get; set; }
    }
}

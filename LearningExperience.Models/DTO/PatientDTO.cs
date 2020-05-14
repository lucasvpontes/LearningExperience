using LearningExperience.Models;
using Newtonsoft.Json;
using System;
using System.Text.Json.Serialization;

namespace LearningExperience.DTO
{
    public class PatientDTO
    {
        [JsonProperty("Patient")]
        public Patient Patient { get; set; }
        public DateTime? RequestDate { get; set; }
    }
}

using LearningExperience.Models;
using System;

namespace LearningExperience.DTO
{
    public class PatientDTO
    {
        public Patient Patient { get; set; }
        public DateTime? RequestDate { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace LearningExperience.Models.DTO
{
    public class PatientsRequestDto
    {
        public List<Patient> Patients { get; set; }
        public DateTime? RequestDate { get; set; }
    }
}
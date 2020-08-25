using System;
using System.Collections.Generic;

namespace LearningExperience.Api.UseCases.GetAllPatients
{
    public class GetAllPatientsRequest
    {
        public List<Patient> Patients { get; set; }
        public DateTime? RequestDate { get; set; }
    }
}
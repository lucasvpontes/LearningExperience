using LearningExperience.DTO;
using LearningExperience.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningExperience.Application.Queries
{
    public interface IPatientQueries
    {
        Task AddPatient(PatientDto patient);
        IEnumerable<Patient> GetAll();
        Task RemovePatient(PatientDto patientRemoved);
        Task UpdatePatient(PatientDto patientUpdated);
        Patient GetPatientById(string patientId);
    }
}


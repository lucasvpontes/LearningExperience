using LearningExperience.DTO;
using LearningExperience.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningExperience.Services
{
    public interface IPatientService
    {
        Task AddPatient(PatientDTO patient);
        IEnumerable<Patient> GetAll();
        Task RemovePatient(PatientDTO patientRemoved);
        Task UpdatePatient(PatientDTO patientUpdated);
        Patient GetPatientById(string patientId);
    }
}


using LearningExperience.DTO;
using LearningExperience.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningExperience.Repository.Interfaces
{
    public interface IPatientRepository
    {
        Task AddPatient(PatientDTO patient);
        IEnumerable<Patient> GetAll();
        Task RemovePatient(string patientId);
        Task UpdatePatient(PatientDTO patientUpdated);
        Patient GetPatientById(string patientId);
    }
}


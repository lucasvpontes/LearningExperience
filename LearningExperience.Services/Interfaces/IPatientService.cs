using LearningExperience.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningExperience.Services
{
    public interface IPatientService
    {
        Task AddPatient(Patient patient);
        IEnumerable<Patient> GetAll();
        Task RemovePatient(Patient patientRemoved);
        Task UpdatePatient(Patient patientUpdated);
        Task UpdateMultiplePatients(List<Patient> patientsUpdated);
    }
}


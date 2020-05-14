using LearningExperience.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningExperience.Services
{
    public interface IPatientService
    {
        Task AddPatient(Patient Patient);
        IEnumerable<Patient> GetAll();
        Task RemovePatient(Patient PatientRemoved);
        Task UpdatePatient(Patient PatientRemoved);
        Task UpdateMultiplePatients(Patient PatientRemoved);
    }
}


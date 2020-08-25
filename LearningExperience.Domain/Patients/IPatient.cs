using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningExperience.Domain.Patients
{
    public interface IPatient
    {
        Task AddPatient(PatientDto patient);
        IEnumerable<Patient> GetAll();
        Task RemovePatient(PatientDto patientRemoved);
        Task UpdatePatient(PatientDto patientUpdated);
        Patient GetPatientById(string patientId);
    }
}


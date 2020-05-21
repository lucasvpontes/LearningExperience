using LearningExperience.Models;
using LearningExperience.Repository;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace LearningExperience.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task AddPatient(Patient patient)
        {
            await _patientRepository.AddPatient(patient);
        }

        public IEnumerable<Patient> GetAll()
        {
            var patients = _patientRepository.GetAll();
            return patients;
        }

        public async Task RemovePatient(Patient patientRemoved)
        {
            await _patientRepository.RemovePatient(patientRemoved);
        }

        public async Task UpdatePatient(Patient patientsUpdated)
        {
            await _patientRepository.UpdatePatient(patientsUpdated);
        }

        public async Task UpdateMultiplePatients(List<Patient> patientsUpdated)
        {
            await _patientRepository.UpdateMultiplePatients(patientsUpdated);
        }
    }
}


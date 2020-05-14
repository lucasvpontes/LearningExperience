using LearningExperience.Models;
using LearningExperience.Repository;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace LearningExperience.Services
{
    public class PatientService: IPatientService
    {
        private readonly IMongoRepository<Patient> _patientRepository;

        public PatientService(IMongoRepository<Patient>patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task AddPatient(Patient Patient)
        {
            await _patientRepository.InsertOneAsync(Patient);
        }

        public IEnumerable<Patient> GetAll()
        {
            var patients = _patientRepository.FilterBy(
                filter => filter.Deleted == false
            );
            return patients;
        }

        public async Task RemovePatient(Patient patientRemoved)
        {
            await _patientRepository.DeleteOneAsync(
                patient => patient.Name == patientRemoved.Name) ;
        }

        public async Task UpdatePatient(Patient patientRemoved)
        {
            var update = Builders<Patient>.Update
            .Set(patient => patient.Name, patientRemoved.Name);
            await _patientRepository.UpdateOneAsync(Patient => Patient.DiseaseLevel == patientRemoved.DiseaseLevel, update);
        }

        public async Task UpdateMultiplePatients(Patient PatientRemoved)
        {
            var update = Builders<Patient>.Update
            .Set(Patient => Patient.Name, PatientRemoved.Name);
            await _patientRepository.UpdateManyAsync(Patient => Patient.DiseaseLevel == PatientRemoved.DiseaseLevel, update);
        }
    }
}


using LearningExperience.Models;
using LearningExperience.Repository;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace LearningExperience.Repository
{
    public class PatientRepository: IPatientRepository
    {
        private readonly IMongoRepository<Patient> _mongoRepository;

        public PatientRepository(IMongoRepository<Patient> mongoRepository)
        {
            _mongoRepository = mongoRepository;
        }

        public async Task AddPatient(Patient Patient)
        {
            await _mongoRepository.InsertOneAsync(Patient);
        }

        public IEnumerable<Patient> GetAll()
        {
            var patients = _mongoRepository.FilterBy(
                filter => filter.Deleted == false
            );
            return patients;
        }

        public async Task RemovePatient(Patient patientRemoved)
        {
            await _mongoRepository.DeleteOneAsync(
                patient => patient.Name == patientRemoved.Name) ;
        }

        public async Task UpdatePatient(Patient patientRemoved)
        {
            var update = Builders<Patient>.Update
            .Set(patient => patient.Name, patientRemoved.Name);
            await _mongoRepository.UpdateOneAsync(Patient => Patient.DiseaseLevel == patientRemoved.DiseaseLevel, update);
        }

        public async Task UpdateMultiplePatients(Patient PatientRemoved)
        {
            var update = Builders<Patient>.Update
            .Set(Patient => Patient.Name, PatientRemoved.Name);
            await _mongoRepository.UpdateManyAsync(Patient => Patient.DiseaseLevel == PatientRemoved.DiseaseLevel, update);
        }
    }
}


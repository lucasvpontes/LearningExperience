using LearningExperience.DTO;
using LearningExperience.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace LearningExperience.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly IMongoRepository<Patient> _mongoRepository;

        public PatientRepository(IMongoRepository<Patient> mongoRepository)
        {
            _mongoRepository = mongoRepository;
        }

        public async Task AddPatient(PatientDTO patientToInsert)
        {
            var patient = new Patient()
            {
                Name = patientToInsert.Name,
                Age = patientToInsert.Age,
                DiseaseLevel = patientToInsert.DiseaseLevel,
                ColorsIssue = patientToInsert.ColorsIssue,
                FavoriteObject = patientToInsert.FavoriteObject,
                FavoriteJoke = patientToInsert.FavoriteJoke,
                FavoritePastTime = patientToInsert.FavoritePastTime,
                Comment = patientToInsert.FavoritePastTime,
                LastUpdate = patientToInsert.LastUpdate
            };
            await _mongoRepository.InsertOneAsync(patient);
        }

        public IEnumerable<Patient> GetAll()
        {
            var patients = _mongoRepository.FilterBy(
                filter => filter.Deleted == false
            );
            return patients;
        }
        public Patient GetPatientById(string patientId)
        {
            return _mongoRepository.FindOne(filter => filter.Id == patientId);
        }

        public async Task RemovePatient(PatientDTO patientRemoved)
        {
            await _mongoRepository.DeleteOneAsync(
                patient => patient.Id == patientRemoved.Id);
        }

        public async Task UpdatePatient(PatientDTO patientUpated)
        {
            var update = Builders<Patient>.Update
            .Set(patient => patient.Name, patientUpated.Name)
            .Set(patient => patient.DiseaseLevel, patientUpated.DiseaseLevel)
            .Set(patient => patient.ColorsIssue, patientUpated.ColorsIssue)
            .Set(patient => patient.FavoriteObject, patientUpated.FavoriteObject)
            .Set(patient => patient.FavoritePastTime, patientUpated.FavoritePastTime)
            .Set(patient => patient.Comment, patientUpated.Comment)
            .Set(patient => patient.LastUpdate, DateTime.Now);
            await _mongoRepository.UpdateOneAsync(Patient => Patient.Id == patientUpated.Id, update);
        }
    }
}


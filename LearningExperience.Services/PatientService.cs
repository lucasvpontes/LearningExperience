﻿using LearningExperience.DTO;
using LearningExperience.Models;
using LearningExperience.Repository.Interfaces;
using LearningExperience.Services.Interfaces;
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

        public async Task AddPatient(PatientDTO patient)
        {
            await _patientRepository.AddPatient(patient);
        }

        public IEnumerable<Patient> GetAll()
        {
            var patients = _patientRepository.GetAll();
            return patients;
        }

        public Patient GetPatientById(string patientId)
        {
            return _patientRepository.GetPatientById(patientId);
        }

        public async Task RemovePatient(string patientId)
        {
            await _patientRepository.RemovePatient(patientId);
        }

        public async Task UpdatePatient(PatientDTO patientsUpdated)
        {
            await _patientRepository.UpdatePatient(patientsUpdated);
        }
    }
}


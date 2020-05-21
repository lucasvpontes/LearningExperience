using LearningExperience.DTO;
using LearningExperience.Models;
using LearningExperience.Models.DTO;
using LearningExperience.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningExperience.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [Route("RegisterPatient")]
        [HttpPost]
        public async Task<OkResult> RegisterPatient(PatientDTO patientDTO)
        {
            await _patientService.AddPatient(patientDTO.Patient);
            return Ok();
        }

        [HttpGet("GetAll")]
        public IEnumerable<Patient> GetAll()
        {
            var patients = _patientService.GetAll();
            return patients;
        }

        [HttpPost("RemovePatient")]
        public async Task<OkResult> RemoveAdvisor(PatientDTO patientDTO)
        {
            await _patientService.RemovePatient(patientDTO.Patient);
            return Ok();
        }

        [HttpPost("UpdatePatient")]
        public async Task<OkResult> UpdateAdvisor(PatientDTO patientDTO)
        {
            await _patientService.UpdatePatient(patientDTO.Patient);
            return Ok();
        }

        [HttpPost("UpdateMultiplePatient")]
        public async Task<OkResult> UpdateMultipleAdvisors(PatientsRequestDTO patientsDTO)
        {
            await _patientService.UpdateMultiplePatients(patientsDTO.Patients);
            return Ok();
        }


    }
}

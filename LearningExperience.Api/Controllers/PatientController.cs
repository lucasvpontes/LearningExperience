using LearningExperience.DTO;
using LearningExperience.Models;
using LearningExperience.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningExperience.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize]
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
            await _patientService.AddPatient(patientDTO);
            return Ok();
        }

        [HttpGet("GetAll")]
        public IEnumerable<Patient> GetAll()
        {
            var patients = _patientService.GetAll();
            //foreach(Patient patient in patients)
            //{
            //   var deseaseLevel =  Enum.GetName(typeof(DiseaseLevel), patient.DiseaseLevel);
            //}

            return patients;
        }

        [HttpPost("RemovePatient")]
        public async Task<OkResult> RemoveAdvisor(PatientDTO patientDTO)
        {
            await _patientService.RemovePatient(patientDTO);
            return Ok();
        }

        [HttpPost("UpdatePatient")]
        public async Task<OkResult> UpdateAdvisor(PatientDTO patientDTO)
        {
            await _patientService.UpdatePatient(patientDTO);
            return Ok();
        }
    }
}

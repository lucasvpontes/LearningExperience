using LearningExperience.DTO;
using LearningExperience.Models;
using LearningExperience.Models.Enums;
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
        public async Task<IActionResult> RegisterPatient(PatientDTO patientDTO)
        {
            await _patientService.AddPatient(patientDTO);
            return Ok(new { StatusCode = ReturnStatusCode.Ok });
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

using LearningExperience.DTO;
using LearningExperience.Models;
using LearningExperience.Models.Enums;
using LearningExperience.Services.Interfaces;
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
        public async Task<OkResult> RemovePatient([FromBody] string patientId)
        {
            await _patientService.RemovePatient(patientId);
            return Ok();
        }

        [HttpPost("UpdatePatient")]
        public async Task<IActionResult> UpdatePatient(PatientDTO patientDTO)
        {
            await _patientService.UpdatePatient(patientDTO);
            return Ok(new { StatusCode = ReturnStatusCode.Ok });
        }

        [HttpGet("GetPatientById")]
        public Patient GetPatientById([FromBody] string patientId)
        {
            var patient = _patientService.GetPatientById(patientId);
            return patient;
        }
    }
}

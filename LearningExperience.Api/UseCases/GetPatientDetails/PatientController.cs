using LearningExperience.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningExperience.Api.UseCases.GetPatientDetails
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

        [HttpGet("GetPatientById")]
        public Patient GetPatientById(string patientId)
        {
            var patient = _patientService.GetPatientById(patientId);
            return patient;
        }
    }
}

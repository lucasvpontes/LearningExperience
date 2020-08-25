using LearningExperience.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LearningExperience.Api.UseCases.InactivePatient
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

        [HttpPost("RemovePatient")]
        public async Task<OkResult> RemovePatient(InactivePatientRequest patientDTO)
        {
            await _patientService.RemovePatient(patientDTO);
            return Ok();
        }
    }
}

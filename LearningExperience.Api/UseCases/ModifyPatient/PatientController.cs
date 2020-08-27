using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LearningExperience.Api.UseCases.ModifyPatient
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

        [HttpPost("UpdatePatient")]
        public async Task<IActionResult> UpdatePatient(ModifyPatientRequest patientDTO)
        {
            await _patientService.UpdatePatient(patientDTO);
            return Ok(new { StatusCode = ReturnStatusCode.Ok });
        }
    }
}

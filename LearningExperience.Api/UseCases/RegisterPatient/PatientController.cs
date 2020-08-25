using LearningExperience.Domain.Patients;
using LearningExperience.Domain.ValueObjects;
using LearningExperience.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LearningExperience.Api.UseCases.RegisterPatient
{

    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize]
    public class PatientController : ControllerBase
    {
        private readonly IPatient _patientService;

        public PatientController(IPatient patientService)
        {
            _patientService = patientService;
        }

        [Route("RegisterPatient")]
        [HttpPost]
        public async Task<IActionResult> RegisterPatient(PatientDto patientDTO)
        {
            await _patientService.AddPatient(patientDTO);
            return Ok(new { StatusCode = ReturnStatusCode.Ok });
        }
}

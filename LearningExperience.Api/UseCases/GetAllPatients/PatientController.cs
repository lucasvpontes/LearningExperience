using LearningExperience.DTO;
using LearningExperience.Models;
using LearningExperience.Models.Enums;
using LearningExperience.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningExperience.Api.UseCases.GetAllPatients
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

        [HttpGet("GetAll")]
        public IEnumerable<Patient> GetAll()
        {
            var patients = _patientService.GetAll();
            return patients;
        }
    }
}

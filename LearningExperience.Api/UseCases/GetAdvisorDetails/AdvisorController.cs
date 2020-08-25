using LearningExperience.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningExperience.Api.UseCases.GetAdvisorDetails
{

    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize]
    public class AdvisorController : ControllerBase
    {
        private readonly IAdvisor _advisorService;

        public AdvisorController(IAdvisor advisorService)
        {
            _advisorService = advisorService;
        }

        [HttpGet("GetAdvisorById")]
        public Advisor GetAdvisorById(string advisorId)
        {
            var advisor = _advisorService.GetAdvisorById(advisorId);
            return advisor;
        }
    }
}

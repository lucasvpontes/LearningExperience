using LearningExperience.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningExperience.Api.UseCases.InactiveAdvisor
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

        [HttpPost("RemoveAdvisor")]
        public async Task<OkResult> RemoveAdvisor(AdvisorDto advisorDTO)
        {
         await _advisorService.RemoveAdvisor(advisorDTO);
            return Ok();
        }
    }
}

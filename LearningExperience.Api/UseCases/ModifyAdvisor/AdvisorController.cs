using LearningExperience.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningExperience.Api.UseCases.ModifyAdvisor
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

        [HttpPost("UpdateAdvisor")]
        public async Task<IActionResult> UpdateAdvisor(InactivateAdvisorRequest advisorDTO)
        {
            await _advisorService.UpdateAdvisor(advisorDTO);
            return Ok(new { StatusCode = ReturnStatusCode.Ok});
        }
    }
}

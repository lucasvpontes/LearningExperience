using LearningExperience.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LearningExperience.Api.UseCases.RegisterAdvisor

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

        [Route("RegisterAdvisor")]
        [HttpPost]
        public async Task<IActionResult> RegisterAdvisor(InactivateAdvisorRequest advisorDTO)
        {
           await _advisorService.AddAdvisor(advisorDTO);
            return Ok(new { StatusCode = ReturnStatusCode.Ok });
        }
    }
}

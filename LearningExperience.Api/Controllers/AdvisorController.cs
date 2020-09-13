using LearningExperience.Models;
using LearningExperience.Models.DTO;
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
    public class AdvisorController : ControllerBase
    {
        private readonly IAdvisorService _advisorService;

        public AdvisorController(IAdvisorService advisorService)
        {
            _advisorService = advisorService;
        }

        [Route("RegisterAdvisor")]
        [HttpPost]
        public async Task<IActionResult> RegisterAdvisor(AdvisorDTO advisorDTO)
        {
           await _advisorService.AddAdvisor(advisorDTO);
            return Ok(new { StatusCode = ReturnStatusCode.Ok });
        }

        [HttpGet("GetAll")]
        public IEnumerable<Advisor> GetAll()
        {
            var advisors = _advisorService.GetAll();
            return advisors;
        }

        [HttpPost("RemoveAdvisor")]
        public async Task<OkResult> RemoveAdvisor([FromBody] string advisorId)
        {
         await _advisorService.RemoveAdvisor(advisorId);
            return Ok();
        }

        [HttpPost("UpdateAdvisor")]
        public async Task<IActionResult> UpdateAdvisor(AdvisorDTO advisorDTO)
        {
            await _advisorService.UpdateAdvisor(advisorDTO);
            return Ok(new { StatusCode = ReturnStatusCode.Ok});
        }

        [HttpGet("GetAdvisorById")]
        public Advisor GetAdvisorById(string advisorId)
        {
            var advisor = _advisorService.GetAdvisorById(advisorId);
            return advisor;
        }
    }
}

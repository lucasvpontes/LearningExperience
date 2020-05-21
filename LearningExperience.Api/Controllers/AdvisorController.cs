using LearningExperience.Models;
using LearningExperience.Models.DTO;
using LearningExperience.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningExperience.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class AdvisorController : ControllerBase
    {
        private readonly IAdvisorService _advisorService;

        public AdvisorController(IAdvisorService advisorService)
        {
            _advisorService = advisorService;
        }

        [Route("RegisterAdvisor")]
        [HttpPost]
        public async Task<OkResult> RegisterAdvisor(AdvisorDTO advisorDTO)
        {
           await _advisorService.AddAdvisor(advisorDTO.Advisor);
            return Ok();
        }

        [HttpGet("GetAll")]
        public IEnumerable<Advisor> GetAll()
        {
            var advisors = _advisorService.GetAll();
            return advisors;
        }

        [HttpPost("RemoveAdvisor")]
        public async Task<OkResult> RemoveAdvisor(AdvisorDTO advisorDTO)
        {
         await _advisorService.RemoveAdvisor(advisorDTO.Advisor);
            return Ok();
        }

        [HttpPost("UpdateAdvisor")]
        public async Task<OkResult> UpdateAdvisor(AdvisorDTO advisorDTO)
        {
            await _advisorService.UpdateAdvisor(advisorDTO.Advisor);
            return Ok();
        }

        [HttpPost("UpdateMultipleAdvisors")]
        public async Task<OkResult> UpdateMultipleAdvisors(AdvisorsRequestDTO advisorsDTO)
        {
            await _advisorService.UpdateMultipleAdvisors(advisorsDTO.Advisors);
            return Ok();
        }


    }
}

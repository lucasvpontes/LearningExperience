using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LearningExperience.Api.UseCases.GetAllAdvisors
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

        [HttpGet("GetAll")]
        public IEnumerable<Advisor> GetAll()
        {
            var advisors = _advisorService.GetAll();
            return advisors;
        }
    }
}

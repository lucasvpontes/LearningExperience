using LearningExperience.Models;
using LearningExperience.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Swashbuckle.AspNetCore.Swagger;

namespace LearningExperience.Api.Controllers
{
    [Route("api/v1/")]
    [ApiController]
    public class ConnectionController : ControllerBase
    {
        /// <summary>
        /// Realizar o teste da API
        /// </summary>
        [Route("ping")]
        [HttpGet]
        public string GetPing() {
            return "Pong!";
        }

    }
}

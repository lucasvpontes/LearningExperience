using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LearningExperience.Controllers
{
    //TO-DO - Alterar para HealthCheck
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class ConnectionController : ControllerBase
    {
        /// <summary>
        /// Realizar o teste da API
        /// </summary>
        [Route("ping")]
        [HttpGet]
        public string GetPing()
        {
            return "Pong!";
        }


    }
}


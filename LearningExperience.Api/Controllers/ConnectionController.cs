using Microsoft.AspNetCore.Mvc;

namespace LearningExperience.Controllers
{

    [Route("api/v1/[controller]")]
    [ApiController]
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


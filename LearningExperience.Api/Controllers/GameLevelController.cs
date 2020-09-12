using LearningExperience.Models.DTO;
using LearningExperience.Models.Enums;
using LearningExperience.Models.Model.Interfaces;
using LearningExperience.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace LearningExperience.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize]
    public class GameLevelController : ControllerBase
    {
        private readonly IGameLevelService _gameLevelService;

        public GameLevelController(IGameLevelService gameLevelService)
        {
            _gameLevelService = gameLevelService;
        }

        [HttpPost("GerenateLevel")]
        public  IGameLevel GenerateLevel(GenerateLevelRequestDTO gameLevelType)
        {
            var gameLevels = _gameLevelService.GenerateLevel(gameLevelType);
            return gameLevels;
        }


        // TODO: Implementar reset.
        [HttpPost("ResetProgress")]
        public async Task<IActionResult> ResetProgress([FromBody] string userId)
        {
            await _gameLevelService.RemoveImage(userId);
            return Ok(new { StatusCode = ReturnStatusCode.Ok });
        }
    }
}

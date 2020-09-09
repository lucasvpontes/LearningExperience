using LearningExperience.Models.DTO;
using LearningExperience.Models.Enums;
using LearningExperience.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LearningExperience.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize]
    public class GameImageLevelController : ControllerBase
    {
        private readonly IGameLevelService _gameLevelService;

        public GameImageLevelController(IGameLevelService gameLevelImageService)
        {
            _gameLevelService = gameLevelImageService;
        }

        [HttpPost("RegisterImage")]
        public async Task<IActionResult> RegisterImage([FromBody] RegisterImageRequestDTO requestDTO)
        {
           await _gameLevelService.RegisterImage(requestDTO);
            return Ok(new { StatusCode = ReturnStatusCode.Ok });
        }

       

        [HttpPost("RemoveImage")]
        public async Task<IActionResult> RemoveImage([FromBody] string imageId)
        {
            await _gameLevelService.RemoveImage(imageId);
            return Ok(new { StatusCode = ReturnStatusCode.Ok});
        }
    }
}

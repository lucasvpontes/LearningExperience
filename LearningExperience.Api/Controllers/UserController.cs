using LearningExperience.Models;
using LearningExperience.Models.DTO;
using LearningExperience.Models.Enums;
using LearningExperience.Services;
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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("RegisterUser")]
        public async Task<IActionResult> RegisterUser([FromBody] AuthenticateUserDTO userDTO)
        {
            await _userService.AddUser(userDTO);
            return Ok(new { StatusCode = ReturnStatusCode.Ok });
        }

        [HttpGet("GetAll")]
        public IEnumerable<User> GetAll()
        {
            var advisors = _userService.GetAll();
            return advisors;
        }

        [HttpPost("RemoveUser")]
        public async Task<OkResult> RemoveUser([FromBody] string userId)
        {
            await _userService.RemoveUser(userId);
            return Ok();
        }

        [HttpPost("UpdateUser")]
        public async Task<OkResult> UpdateUser(UserDTO userDTO)
        {
            await _userService.UpdateUser(userDTO);
            return Ok();
        }

        [HttpPost("GetUserProgress")]
        public double GetUserProgress(UserProgressDTO userProgress)
        {
            return _userService.GetUserProgress(userProgress);
        }

        [HttpPost("UpdateUserProgress")]
        public async Task<IActionResult> UpdateUserProgress(UserProgressDTO userProgress)
        {
            await  _userService.UpdateUserProgress(userProgress);
            return Ok(new { StatusCode = ReturnStatusCode.Ok });
        }
    }
}

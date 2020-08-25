using LearningExperience.Models;
using LearningExperience.Models.DTO;
using LearningExperience.Models.Enums;
using LearningExperience.Services;
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

        [Route("RegisterUser")]
        [HttpPost]
        public async Task<IActionResult> RegisterUser(AuthenticateUserDto userDTO)
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
        public async Task<OkResult> RemoveUser(AuthenticateUserDto userDTO)
        {
            await _userService.RemoveUser(userDTO);
            return Ok();
        }

        [HttpPost("UpdateUser")]
        public async Task<OkResult> UpdateUser(AuthenticateUserDto userDTO)
        {
            await _userService.UpdateUser(userDTO);
            return Ok();
        }

    }
}

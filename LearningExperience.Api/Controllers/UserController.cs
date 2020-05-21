using LearningExperience.Models;
using LearningExperience.Models.DTO;
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
        public async Task<OkResult> RegisterUser(UserDTO userDTO)
        {
            await _userService.AddUser(userDTO.User);
            return Ok();
        }

        [HttpGet("GetAll")]
        public IEnumerable<User> GetAll()
        {
            var advisors = _userService.GetAll();
            return advisors;
        }

        [HttpPost("RemoveUser")]
        public async Task<OkResult> RemoveUser(UserDTO userDTO)
        {
            await _userService.RemoveUser(userDTO.User);
            return Ok();
        }

        [HttpPost("UpdateUser")]
        public async Task<OkResult> UpdateUser(UserDTO userDTO)
        {
            await _userService.UpdateUser(userDTO.User);
            return Ok();
        }

        [HttpPost("UpdateMultipleUsers")]
        public async Task<OkResult> UpdateMultipleUsers(UsersRequestDTO usersDTO)
        {
            await _userService.UpdateMultipleUsers(usersDTO.Users);
            return Ok();
        }
    }
}

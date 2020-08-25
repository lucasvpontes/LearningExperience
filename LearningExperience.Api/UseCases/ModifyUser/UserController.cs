using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LearningExperience.Api.UseCases.ModifyUser
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

        [HttpPost("UpdateUser")]
        public async Task<OkResult> UpdateUser(AuthenticateUserDto userDTO)
        {
            await _userService.UpdateUser(userDTO);
            return Ok();
        }

    }
}

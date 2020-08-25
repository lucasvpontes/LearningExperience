using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LearningExperience.Api.UseCases.InactiveUser
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
        //TO-DO - From body nos request - Nao esquecer
        [HttpPost("RemoveUser")]
        public async Task<OkResult> RemoveUser(AuthenticateUserDto userDTO)
        {
            await _userService.RemoveUser(userDTO);
            return Ok();
        }

    }
}

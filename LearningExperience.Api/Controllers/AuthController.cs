using LearningExperience.Models;
using LearningExperience.Models.DTO;
using LearningExperience.Models.Enums;
using LearningExperience.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LearningExperience.Api.Controllers
{
    [Route("api/v1/[controller]")]
    public class AuthController : Controller
    {
        private readonly IJwtTokenSettings _jwtTokenSettings;
        private readonly IUserService _userService;
        private readonly IAuthService _authService;
        Dictionary<string, string> tokenParams;
        public AuthController(IJwtTokenSettings jwtTokenSettings, IUserService userService, IAuthService authService)
        {
            _jwtTokenSettings = jwtTokenSettings;
            _userService = userService;
            _authService = authService;
            tokenParams = new Dictionary<string, string>();

        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult CreateToken([FromBody] AuthenticateUserDTO userDTO)
        {
            if (userDTO.Email == null) return Ok(new { Status = ReturnStatusCode.NotAuthorized, Message = "Usuário ou senha incorretos" });

            string tokenString = string.Empty;
            tokenParams.Add("secretKey", _jwtTokenSettings.SecretKey);
            tokenParams.Add("issuer", _jwtTokenSettings.Issuer);
            tokenParams.Add("audience", _jwtTokenSettings.Audience);
            tokenParams.Add("tokenExpirity", _jwtTokenSettings.TokenExpiry);
            bool IsvalidUser = _userService.ValidateUser(userDTO);
            var validUser = _userService.GetUserByLogin(userDTO);

            if (IsvalidUser)
            {

                tokenString = _authService.BuildJWTToken(tokenParams);
                return Ok(new { Status = ReturnStatusCode.Ok, Token = tokenString, TokenExpiresIn = _jwtTokenSettings.TokenExpiry, Id = validUser.Id });
            }
            else
            {
                return Ok(new { Status = ReturnStatusCode.NotAuthorized, Message = "Usuário ou senha incorretos" });
            }
        }
        [Route("RegisterLogin")]
        [AllowAnonymous]
        [HttpPost]
        public IActionResult RegisterLogin([FromBody] AuthenticateUserDTO userDTO)
        {
            _userService.AddUser(userDTO);
            return Ok(new { StatusCode = ReturnStatusCode.Ok });
        }
    }
}

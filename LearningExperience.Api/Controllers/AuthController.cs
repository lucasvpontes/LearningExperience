using LearningExperience.Models;
using LearningExperience.Models.DTO;
using LearningExperience.Models.Enums;
using LearningExperience.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<IActionResult> CreateToken([FromBody] AuthenticateUserDTO userDTO)
        {
            if (userDTO.Email == null) return Ok(new { Status = ReturnStatusCode.NotAuthorized, Message = "Usuário ou senha incorretos" });


            bool IsvalidUser = _userService.ValidateUser(userDTO);
            var validUser = await _userService.GetUserByLogin(userDTO);
            AddParamsToJWT();
            if (IsvalidUser)
            {
                var tokenString = _authService.BuildJWTToken(tokenParams);
                return Ok(new { Status = ReturnStatusCode.Ok, Token = tokenString, TokenExpiresIn = _jwtTokenSettings.TokenExpiry, validUser.Id, UserName = validUser.Name });
            }
            else
            {
                return Ok(new { Status = ReturnStatusCode.NotAuthorized, Message = "Usuário ou senha incorretos" });
            }
        }
        [Route("RegisterLogin")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> RegisterLogin([FromBody] AuthenticateUserDTO userDTO)
        {
            var email = string.IsNullOrEmpty(userDTO.Email);
            var password = string.IsNullOrEmpty(userDTO.Password);
            var name = string.IsNullOrEmpty(userDTO.Name);

            if (email || password || name)
                return Unauthorized(new { ReturnStatusCode.NotAuthorized, Message = "Usuário, senha ou nome vazio", IsSignuped = false });

            if (userDTO.Password != userDTO.RepeatPassword)
                return Unauthorized(new { ReturnStatusCode.NotAuthorized, Message = "Senhas não indenticas", IsSignuped = false });

            await _userService.AddUser(userDTO);
            AddParamsToJWT();

            var validUser = await _userService.GetUserByLogin(userDTO);

            var levels = Enum.GetValues(typeof(GameLevelType));

            foreach (GameLevelType level in levels)
            {
                var userProgress = new UserProgressDTO
                {
                    UserId = validUser.Id,
                    Module = level          
                };
                _userService.InsertUserProgress(userProgress);
            }

            var tokenString = _authService.BuildJWTToken(tokenParams);
            return Ok(new { StatusCode = ReturnStatusCode.Ok, Message = "Cadastrado com sucesso", Token = tokenString, IsSignuped = true, validUser.Id, UserName = validUser.Name });
        }

        private Dictionary<string, string> AddParamsToJWT()
        {
            tokenParams.Add("secretKey", _jwtTokenSettings.SecretKey);
            tokenParams.Add("issuer", _jwtTokenSettings.Issuer);
            tokenParams.Add("audience", _jwtTokenSettings.Audience);
            tokenParams.Add("tokenExpirity", _jwtTokenSettings.TokenExpiry);
            return tokenParams;
        }
    }
}

using LearningExperience.Application.Repositories;
using LearningExperience.Domain.Authentication;
using LearningExperience.Domain.Users;
using LearningExperience.Domain.ValueObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LearningExperience.Api.UseCases.SignIn
{
    [Route("api/v1/[controller]")]
    public class UserController : Controller
    {
        private readonly IJwtTokenSettings _jwtTokenSettings;
        private readonly IUser _userService;
        private readonly IAuth _authService;
        Dictionary<string, string> tokenParams;
        public UserController(IJwtTokenSettings jwtTokenSettings, IUser userService, IAuth authService)
        {
            _jwtTokenSettings = jwtTokenSettings;
            _userService = userService;
            _authService = authService;
            tokenParams = new Dictionary<string, string>();

        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult CreateToken([FromBody] AuthenticateUserDto userDTO)
        {
            if (userDTO.Email == null) return Ok(new { Status = ReturnStatusCode.NotAuthorized, Message = "Usuário ou senha incorretos" });

            string tokenString = string.Empty;

            bool IsvalidUser = _userService.ValidateUser(userDTO);
            var validUser = _userService.GetUserByLogin(userDTO);
            AddParamsToJWT();
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
            var email = string.IsNullOrEmpty(userDTO.Email);
            var password = string.IsNullOrEmpty(userDTO.Password);
            var name = string.IsNullOrEmpty(userDTO.Name);
            string tokenString = string.Empty;

            if (email || password || name)
                return Unauthorized(new { ReturnStatusCode.NotAuthorized, Message = "Usuário, senha ou nome vazio", IsSignuped = false });

            if (userDTO.Password != userDTO.RepeatPassword)
                return Unauthorized(new { ReturnStatusCode.NotAuthorized, Message = "Senhas não indenticas", IsSignuped = false });

            _userService.AddUser(userDTO);
            AddParamsToJWT();

            tokenString = _authService.BuildJWTToken(tokenParams);
            return Ok(new { StatusCode = ReturnStatusCode.Ok, Message = "Cadastrado com sucesso", IsSignuped = true });
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
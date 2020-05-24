using LearningExperience.Models;
using LearningExperience.Models.DTO;
using LearningExperience.Models.Enums;
using LearningExperience.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace LearningExperience.Api.Controllers
{
    [Route("api/v1/[controller]")]
    public class AuthController : Controller
    {
        private readonly IJwtTokenSettings _jwtTokenSettings;
        private readonly IUserService _userService;
        Dictionary<string, string> tokenParams;
        public AuthController(IJwtTokenSettings jwtTokenSettings, IUserService userService)
        {
            _jwtTokenSettings = jwtTokenSettings;
            _userService = userService;
            tokenParams = new Dictionary<string, string>();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult CreateToken([FromBody] AuthenticateUserDTO userDTO)
        {
            if (userDTO.Email == null) return Unauthorized(new { Message = "Usuário ou senha incorretos" });

            string tokenString = string.Empty;
            tokenParams.Add("SecretKey", _jwtTokenSettings.SecretKey);
            tokenParams.Add("issuer", _jwtTokenSettings.Issuer);
            tokenParams.Add("audience", _jwtTokenSettings.Audience);
            tokenParams.Add("tokenExpirity", _jwtTokenSettings.TokenExpiry);
            bool IsvalidUser = _userService.ValidateUser(userDTO);
            var validUser = _userService.GetUserByLogin(userDTO);

            if (IsvalidUser)
            {

                tokenString = BuildJWTToken();
                return Ok(new { Token = tokenString, TokenExpiresIn = _jwtTokenSettings.TokenExpiry, Id = validUser.Id });
            }
            else
            {
                return Unauthorized(new { Message = "Usuário ou senha incorretos" });
            }
        }

        [Route("api/v1/[controller]/RegisterLogin")]
        [AllowAnonymous]
        [HttpPost]
        public IActionResult RegisterLogin([FromBody] AuthenticateUserDTO userDTO)
        {
            return Ok();
        }

        private string BuildJWTToken()
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtTokenSettings.SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var issuer = _jwtTokenSettings.Issuer;
            var audience = _jwtTokenSettings.Audience;
            var jwtValidity = DateTime.Now.AddMinutes(Convert.ToDouble(_jwtTokenSettings.TokenExpiry));

            var token = new JwtSecurityToken(issuer,
              audience,
              expires: jwtValidity,
              signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


    }
}

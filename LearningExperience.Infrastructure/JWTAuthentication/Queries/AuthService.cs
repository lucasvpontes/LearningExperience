using LearningExperience.Models;
using LearningExperience.Models.DTO;
using LearningExperience.Repository;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;


namespace LearningExperience.Services
{
    public class AuthService: IAuthService
    {

        public string BuildJWTToken(Dictionary<string, string> tokenParams)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenParams.GetValueOrDefault("secretKey")));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var issuer = tokenParams.GetValueOrDefault("issuer");
            var audience = tokenParams.GetValueOrDefault("audience");
            DateTime jwtValidity = DateTime.Now.AddMinutes(Convert.ToDouble(tokenParams.GetValueOrDefault("tokenExpirity")));

            var token = new JwtSecurityToken(issuer,
              audience,
              expires: jwtValidity,
              signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}


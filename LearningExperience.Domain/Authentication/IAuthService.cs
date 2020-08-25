using LearningExperience.Models;
using LearningExperience.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningExperience.Services
{
    public interface IAuthService
    {
        string BuildJWTToken(Dictionary<string, string> tokenParams);
    }
}


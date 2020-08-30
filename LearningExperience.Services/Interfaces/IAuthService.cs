using System.Collections.Generic;

namespace LearningExperience.Services.Interfaces
{
    public interface IAuthService
    {
        string BuildJWTToken(Dictionary<string, string> tokenParams);
    }
}


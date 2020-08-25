using System.Collections.Generic;

namespace LearningExperience.Domain.Authentication
{
    public interface IAuth
    {
        string BuildJWTToken(Dictionary<string, string> tokenParams);
    }
}


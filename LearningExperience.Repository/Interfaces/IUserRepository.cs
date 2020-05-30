using LearningExperience.Models;
using LearningExperience.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningExperience.Repository
{
    public interface IUserRepository
    {
        Task AddUser(AuthenticateUserDTO user);
        IEnumerable<User> GetAll();
        Task RemoveUser(AuthenticateUserDTO user);
        Task UpdateUser(AuthenticateUserDTO user);
        bool ValidateUser(AuthenticateUserDTO user);
        User GetUserByLogin(AuthenticateUserDTO userAuth);
        User VerifyIfUserExists(AuthenticateUserDTO userAuth);
    }
}


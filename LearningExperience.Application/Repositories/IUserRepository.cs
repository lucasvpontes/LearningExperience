using LearningExperience.Models;
using LearningExperience.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningExperience.Application.Repositories
{
    public interface IUserRepository
    {
        Task AddUser(AuthenticateUserDto user);
        IEnumerable<User> GetAll();
        Task RemoveUser(AuthenticateUserDto user);
        Task UpdateUser(AuthenticateUserDto user);
        bool ValidateUser(AuthenticateUserDto user);
        User GetUserByLogin(AuthenticateUserDto userAuth);
        User VerifyIfUserExists(AuthenticateUserDto userAuth);
    }
}


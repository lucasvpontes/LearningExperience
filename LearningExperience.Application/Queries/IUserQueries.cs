using LearningExperience.Models;
using LearningExperience.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningExperience.Application.Queries
{
    public interface IUserQueries
    {
        Task AddUser(AuthenticateUserDto user);
        IEnumerable<User> GetAll();
        Task RemoveUser(AuthenticateUserDto user);
        Task UpdateUser(AuthenticateUserDto user);
        bool ValidateUser(AuthenticateUserDto user);
        User GetUserByLogin(AuthenticateUserDto user);
    }
}


using LearningExperience.Models;
using LearningExperience.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningExperience.Repository
{
    public interface IUserRepository
    {
        Task AddUser(User user);
        IEnumerable<User> GetAll();
        Task RemoveUser(User user);
        Task UpdateUser(User user);
        Task UpdateMultipleUsers(List<User> users);
        bool ValidateUser(AuthenticateUserDTO user);
        User GetUserByLogin(AuthenticateUserDTO userAuth);
    }
}


using LearningExperience.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningExperience.Services
{
    public interface IUserService
    {
        Task AddUser(User user);
        IEnumerable<User> GetAll();
        Task RemoveUser(User user);
        Task UpdateUser(User user);
        Task UpdateMultipleUsers(List<User> usersUpdated);
    }
}


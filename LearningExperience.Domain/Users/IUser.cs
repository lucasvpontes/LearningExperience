using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningExperience.Domain.Users
{
    public interface IUser
    {
        Task AddUser(AuthenticateUserDto user);
        IEnumerable<User> GetAll();
        Task RemoveUser(AuthenticateUserDto user);
        Task UpdateUser(AuthenticateUserDto user);
        bool ValidateUser(AuthenticateUserDto user);
        User GetUserByLogin(AuthenticateUserDto user);
    }
}


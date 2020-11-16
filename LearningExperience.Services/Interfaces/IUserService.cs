using LearningExperience.Models;
using LearningExperience.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningExperience.Services.Interfaces
{
    public interface IUserService
    {
        Task AddUser(AuthenticateUserDTO user);
        IEnumerable<User> GetAll();
        Task RemoveUser(string userId);
        Task UpdateUser(UserDTO user);
        Task<User> GetUserByLogin(AuthenticateUserDTO user);
        bool ValidateUser(AuthenticateUserDTO user);
        double GetProgressByModule(UserProgressDTO userProgress);
        Task UpdateUserProgress(UserProgressUpdateDTO userProgress);
        IList<UserProgressResultDTO> GetProgressByUser(string userId);
        UserReturnDTO GetUserById(string userId);
        public void InsertUserProgress(UserProgressDTO userProgress);
    }
}


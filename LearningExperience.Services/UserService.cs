using LearningExperience.Models;
using LearningExperience.Models.DTO;
using LearningExperience.Repository.Interfaces;
using LearningExperience.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace LearningExperience.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task AddUser(AuthenticateUserDTO user)
        {
            if(!VerifyIfUserExists(user))
            await _userRepository.AddUser(user);
        }

        public IEnumerable<User> GetAll()
        {
            var users = _userRepository.GetAll();
            return users;
        }

        public async Task RemoveUser(string userId)
        {
            await _userRepository.RemoveUser(userId);
        }

        public async Task UpdateUser(UserDTO user)
        {
            await _userRepository.UpdateUser(user);
        }

        public bool ValidateUser(AuthenticateUserDTO user)
        {
            return _userRepository.ValidateUser(user);
        }

        public User GetUserByLogin(AuthenticateUserDTO user)
        {
            return _userRepository.GetUserByLogin(user);
        }

        private bool VerifyIfUserExists(AuthenticateUserDTO user)
        {
            var userAuth = _userRepository.VerifyIfUserExists(user);

            if (userAuth == null)
                return false;

            return true;
        }

        public double GetUserProgress(UserProgressDTO userProgress)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateUserProgress(UserProgressDTO userProgress)
        {
            throw new System.NotImplementedException();
        }
    }
}


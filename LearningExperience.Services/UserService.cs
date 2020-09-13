using LearningExperience.Models;
using LearningExperience.Models.DTO;
using LearningExperience.Models.Model;
using LearningExperience.Repository.Interfaces;
using LearningExperience.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace LearningExperience.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserProgressRepository _userProgressRepository;

        public UserService(
            IUserRepository userRepository, 
            IUserProgressRepository userProgressRepository)
        {
            _userRepository = userRepository;
            _userProgressRepository = userProgressRepository;
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

        public UserProgress GetUserProgress(UserProgressDTO userProgress)
        {
            return _userProgressRepository.GetUserProgress(userProgress);
        }

        public async Task UpdateUserProgress(UserProgressUpdateDTO userProgress)
        {
            await _userProgressRepository.UpdateUserProgress(userProgress);
        }
    }
}


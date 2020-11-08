
using LearningExperience.Models;
using LearningExperience.Models.DTO;
using LearningExperience.Models.Model;
using LearningExperience.Repository.Interfaces;
using LearningExperience.Services.Interfaces;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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
            if (!VerifyIfUserExists(user))
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

        public double GetProgressByModule(UserProgressDTO userProgress)
        {
            return _userProgressRepository.GetProgressByModule(userProgress);
        }

        public async Task UpdateUserProgress(UserProgressUpdateDTO userProgress)
        {
            await _userProgressRepository.UpdateUserProgress(userProgress);
        }
        public IList<UserProgressResultDTO> GetProgressByUser(string userId)
        {
            var progressList = _userProgressRepository.GetProgressByUser(userId);
            var progressResultList = new List<UserProgressResultDTO>();
            foreach(UserProgress userProgress in progressList)
            {
                var userProgressResult = new UserProgressResultDTO()
                {
                    Progress = userProgress.Progress / 100,
                    Module = userProgress.Module
                };
                progressResultList.Add(userProgressResult);
            }
            return progressResultList;
        }

        public UserReturnDTO GetUserById(string id)
        {
            return _userRepository.GetUserById(id);
        }
    }
}


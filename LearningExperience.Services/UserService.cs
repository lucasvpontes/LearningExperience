using LearningExperience.Models;
using LearningExperience.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace LearningExperience.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task AddUser(User user)
        {
            await _userRepository.AddUser(user);
        }

        public IEnumerable<User> GetAll()
        {
            var users = _userRepository.GetAll();
            return users;
        }

        public async Task RemoveUser(User userRemoved)
        {
            await _userRepository.RemoveUser(userRemoved);
        }

        public async Task UpdateUser(User user)
        {
            await _userRepository.UpdateUser(user);
        }

        public async Task UpdateMultipleUsers(List<User> usersUpdated)
        {
            await _userRepository.UpdateMultipleUsers(usersUpdated); 
        }
    }
}


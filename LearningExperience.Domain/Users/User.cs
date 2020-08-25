using LearningExperience.Application.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace LearningExperience.Domain.Users
{
    public class User : IUser
    {
        private readonly IUserRepository _userRepository;

        public User(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task AddUser(AuthenticateUserDto user)
        {
            if(!VerifyIfUserExists(user))
            await _userRepository.AddUser(user);
        }

        public IEnumerable<User> GetAll()
        {
            var users = _userRepository.GetAll();
            return users;
        }

        public async Task RemoveUser(AuthenticateUserDto userRemoved)
        {
            await _userRepository.RemoveUser(userRemoved);
        }

        public async Task UpdateUser(AuthenticateUserDto user)
        {
            await _userRepository.UpdateUser(user);
        }

        public bool ValidateUser(AuthenticateUserDto user)
        {
            return _userRepository.ValidateUser(user);
        }

        public User GetUserByLogin(AuthenticateUserDto user)
        {
            return _userRepository.GetUserByLogin(user);
        }

        private bool VerifyIfUserExists(AuthenticateUserDto user)
        {
            var userAuth = _userRepository.VerifyIfUserExists(user);

            if (userAuth == null)
                return false;

            return true;
        }

    }
}



using LearningExperience.Models;
using LearningExperience.Models.DTO;
using LearningExperience.Repository.Interfaces;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace LearningExperience.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoRepository<User> _mongoRepository;

        public UserRepository(IMongoRepository<User> mongoRepository)
        {
            _mongoRepository = mongoRepository;
        }

        public async Task AddUser(AuthenticateUserDTO user)
        {
            var newUser = new User()
            {
                Email = user.Email,
                Password = user.Password,
                Name = user.Name
            };

            await _mongoRepository.InsertOneAsync(newUser);
        }

        public IEnumerable<User> GetAll()
        {
            var users = _mongoRepository.FilterBy(
                filter => filter.Deleted == false
            );
            return users;
        }

        public async Task RemoveUser(string userId)
        {
            await _mongoRepository.DeleteOneAsync(
                user => user.Id == userId);
        }

        public async Task UpdateUser(UserDTO userUpdated)
        {
            var update = Builders<User>.Update
            .Set(user => user.Id, userUpdated.Id)
            .Set(user => user.Name, userUpdated.Name)
            .Set(user => user.Email, userUpdated.Email)
            .Set(user => user.Password, userUpdated.Password);

            await _mongoRepository.UpdateOneAsync(user => user.Id == userUpdated.Id, update);
        }

        public bool ValidateUser(AuthenticateUserDTO userAuth)
        {
            var validUser = _mongoRepository.FindOne(user => user.Email == userAuth.Email && user.Password == userAuth.Password);

            if (validUser == null)
                return false;
            else
                return true;
        }

        public User GetUserByLogin(AuthenticateUserDTO userAuth)
        {
            return _mongoRepository.FindOne(user => user.Email == userAuth.Email && user.Password == userAuth.Password);
        }

        public User VerifyIfUserExists(AuthenticateUserDTO userDTO)
        {
            return _mongoRepository.FindOne(user => user.Email == userDTO.Email);
        }
        public UserReturnDTO GetUserById(string id)
        {
            User user = _mongoRepository.FindById(id);
            UserReturnDTO userDTO = new UserReturnDTO(user);
            return userDTO;
        }
    }
}


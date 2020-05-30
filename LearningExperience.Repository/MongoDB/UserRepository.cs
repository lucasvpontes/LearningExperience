using Castle.Core.Internal;
using LearningExperience.Models;
using LearningExperience.Models.DTO;
using LearningExperience.Repository;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
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

        public async Task RemoveUser(AuthenticateUserDTO userRemoved)
        {
            await _mongoRepository.DeleteOneAsync(
                user => user.Email == userRemoved.Email);
        }

        public async Task UpdateUser(AuthenticateUserDTO userUpdated)
        {
            var update = Builders<User>.Update
            .Set(user => user.Id, userUpdated.Id);
            await _mongoRepository.UpdateOneAsync(user => user.Id == userUpdated.Id, update);
        }

        public bool ValidateUser(AuthenticateUserDTO userAuth)
        {
            var validUser = _mongoRepository.FindOne(user => user.Email == userAuth.Email && user.Password == userAuth.Password);
           
            if(validUser == null)
                 return false;
             else
                 return true;
        }

        public User GetUserByLogin(AuthenticateUserDTO userAuth)
        {
            return _mongoRepository.FindOne(user => user.Email == userAuth.Email && user.Password == userAuth.Password);
        }

        public User VerifyIfUserExists(AuthenticateUserDTO userAuth)
        {
           return _mongoRepository.FindOne(user => user.Email == userAuth.Email);
        }
    }
}


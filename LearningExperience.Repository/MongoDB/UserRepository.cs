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

        public async Task AddUser(User user)
        {
            await _mongoRepository.InsertOneAsync(user);
        }

        public IEnumerable<User> GetAll()
        {
            var users = _mongoRepository.FilterBy(
                filter => filter.Deleted == false
            );
            return users;
        }

        public async Task RemoveUser(User userRemoved)
        {
            await _mongoRepository.DeleteOneAsync(
                user => user.Name == userRemoved.Name);
        }

        public async Task UpdateUser(User userUpdated)
        {
            var update = Builders<User>.Update
            .Set(user => user.Id, userUpdated.Id);
            await _mongoRepository.UpdateOneAsync(user => user.Id == userUpdated.Id, update);
        }

        public async Task UpdateMultipleUsers(List<User> usersUpdated)
        {
            foreach (User userUpdated in usersUpdated)
            {
                var update = Builders<User>.Update
                .Set(user => user.Name, userUpdated.Name);
                await _mongoRepository.UpdateManyAsync(user => user.Name == userUpdated.Name, update);
            }
        }

        public bool ValidateUser(AuthenticateUserDTO userAuth)
        {
            var validUser = _mongoRepository.FindOne(user => user.Email == userAuth.Email && user.Password == userAuth.Password);
           
            if(validUser == null)
            {
                return false;
            } else
            {
                return true;
            }
           
        }

        public User GetUserByLogin(AuthenticateUserDTO userAuth)
        {
            return _mongoRepository.FindOne(user => user.Email == userAuth.Email && user.Password == userAuth.Password);
        }
    }
}


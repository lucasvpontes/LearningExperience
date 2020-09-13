using LearningExperience.Models.DTO;
using LearningExperience.Models.Model;
using LearningExperience.Repository.Interfaces;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace LearningExperience.Repository.MongoDB
{
    public class UserProgressRepository : IUserProgressRepository
    {
        private readonly IMongoRepository<UserProgress> _mongoRepository;

        public UserProgressRepository(IMongoRepository<UserProgress> mongoRepository)
        {
            _mongoRepository = mongoRepository;
        }
        public double GetUserProgress(UserProgressDTO userProgress)
        {
            var user = _mongoRepository.FindOne(user => user.UserId == userProgress.UserId && user.Module == userProgress.Module);

            if (user is null)
            {
                InsertUserProgress(userProgress);
                user = _mongoRepository.FindOne(userSelected => userSelected.UserId == userProgress.UserId && userSelected.Module == userProgress.Module);
            }

            return user.Progress/100;
        }

        public async Task UpdateUserProgress(UserProgressUpdateDTO userProgress)
        {
            var update = Builders<UserProgress>.Update
            .Set(user => user.Progress, userProgress.Progress * 100)
            .Set(user => user.LastUpdate, DateTime.Now);

            await _mongoRepository.UpdateOneAsync(filter => filter.UserId == userProgress.Id, update);
        }

        private void InsertUserProgress(UserProgressDTO userProgress)
        {
            UserProgress user = new UserProgress()
            {
                UserId = userProgress.UserId,
                Module = userProgress.Module,
                Progress = 0
            };
            _mongoRepository.InsertOne(user);
        }
    }
}

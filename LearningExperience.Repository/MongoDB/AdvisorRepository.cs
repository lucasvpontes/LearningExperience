using LearningExperience.Models;
using LearningExperience.Repository;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace LearningExperience.Repository
{
    public class AdvisorRepository: IAdvisorRepository
    {
        private readonly IMongoRepository<Advisor> _mongoRepository;

        public AdvisorRepository(IMongoRepository<Advisor> mongoRepository)
        {
            _mongoRepository = mongoRepository;
        }

        public async Task AddAdvisor(Advisor advisor)
        {
            await _mongoRepository.InsertOneAsync(advisor);
        }

        public IEnumerable<Advisor> GetAll()
        {
            var advisors = _mongoRepository.FilterBy(
                filter => filter.Deleted == false
            );
            return advisors;
        }

        public async Task RemoveAdvisor(Advisor advisorRemoved)
        {
            await _mongoRepository.DeleteOneAsync(
                advisor => advisor.Name == advisorRemoved.Name) ;
        }

        public async Task UpdateAdvisor(Advisor advisorRemoved)
        {
            var update = Builders<Advisor>.Update
            .Set(advisor => advisor.Name, advisorRemoved.Name);
            await _mongoRepository.UpdateOneAsync(advisor => advisor.Name == advisorRemoved.Name, update);
        }

        public async Task UpdateMultipleAdvisors(Advisor advisorRemoved)
        {
            var update = Builders<Advisor>.Update
            .Set(advisor => advisor.Name, advisorRemoved.Name);
            await _mongoRepository.UpdateManyAsync(advisor => advisor.Name == advisorRemoved.Name, update);
        }
    }
}


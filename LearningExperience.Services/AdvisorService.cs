using LearningExperience.Models;
using LearningExperience.Repository;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace LearningExperience.Services
{
    public class AdvisorService: IAdvisorService
    {
        private readonly IMongoRepository<Advisor> _advisorRepository;

        public AdvisorService(IMongoRepository<Advisor> advisorRepository)
        {
            _advisorRepository = advisorRepository;
        }

        public async Task AddAdvisor(Advisor advisor)
        {
            await _advisorRepository.InsertOneAsync(advisor);
        }

        public IEnumerable<Advisor> GetAll()
        {
            var advisors = _advisorRepository.FilterBy(
                filter => filter.Deleted == false
            );
            return advisors;
        }

        public async Task RemoveAdvisor(Advisor advisorRemoved)
        {
            await _advisorRepository.DeleteOneAsync(
                advisor => advisor.Name == advisorRemoved.Name) ;
        }

        public async Task UpdateAdvisor(Advisor advisorRemoved)
        {
            var update = Builders<Advisor>.Update
            .Set(advisor => advisor.Name, advisorRemoved.Name);
            await _advisorRepository.UpdateOneAsync(advisor => advisor.Name == advisorRemoved.Name, update);
        }

        public async Task UpdateMultipleAdvisors(Advisor advisorRemoved)
        {
            var update = Builders<Advisor>.Update
            .Set(advisor => advisor.Name, advisorRemoved.Name);
            await _advisorRepository.UpdateManyAsync(advisor => advisor.Name == advisorRemoved.Name, update);
        }
    }
}


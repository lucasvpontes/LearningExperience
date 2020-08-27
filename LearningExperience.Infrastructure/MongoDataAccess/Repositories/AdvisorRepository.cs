using LearningExperience.Application.Repositories;
using LearningExperience.Infrastructure.MongoDataAccess.Entities;
using LearningExperience.Models.DTO;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace LearningExperience.Infrastructure.MongoDataAccess.Repositories
{
    public class AdvisorRepository : IAdvisorRepository
    {
        private readonly IMongoRepository<Advisor> _mongoRepository;

        public AdvisorRepository(IMongoRepository<Advisor> mongoRepository)
        {
            _mongoRepository = mongoRepository;
        }

        public async Task AddAdvisor(InactivateAdvisorRequest advisorInsert)
        {
            Advisor advisor = new Advisor()
            {
                Name = advisorInsert.Name,
                Profession = advisorInsert.Profession,
                Education = advisorInsert.Education,
                Specialization = advisorInsert.Specialization,
                Comment = advisorInsert.Comment,
            };
            await _mongoRepository.InsertOneAsync(advisor);
        }

        public IEnumerable<Advisor> GetAll()
        {
            var advisors = _mongoRepository.FilterBy(
                filter => filter.Deleted == false
            );
            return advisors;
        }

        public async Task RemoveAdvisor(InactivateAdvisorRequest advisorRemoved)
        {
            await _mongoRepository.DeleteOneAsync(
                advisor => advisor.Id == advisorRemoved.Id);
        }

        public async Task UpdateAdvisor(InactivateAdvisorRequest advisorUpdated)
        {
            var update = Builders<Advisor>.Update
            .Set(advisor => advisor.Name, advisorUpdated.Name)
            .Set(advisor => advisor.Profession, advisorUpdated.Profession)
            .Set(advisor => advisor.Education, advisorUpdated.Education)
            .Set(advisor => advisor.Specialization, advisorUpdated.Specialization)
            .Set(advisor => advisor.Comment, advisorUpdated.Comment)
            .Set(advisor => advisor.LastUpdate, DateTime.Now);

            await _mongoRepository.UpdateOneAsync(advisor => advisor.Id == advisorUpdated.Id, update);
        }


        public Advisor GetAdvisorById(string advisorId)
        {
            return _mongoRepository.FindOne(filter => filter.Id == advisorId);
        }

    }
}


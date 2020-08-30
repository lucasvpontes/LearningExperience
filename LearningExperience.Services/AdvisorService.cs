using LearningExperience.Models;
using LearningExperience.Models.DTO;
using LearningExperience.Repository;
using LearningExperience.Repository.Interfaces;
using LearningExperience.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace LearningExperience.Services
{
    public class AdvisorService: IAdvisorService
    {
        private readonly IAdvisorRepository _advisorRepository;

        public AdvisorService(IAdvisorRepository advisorRepository)
        {
            _advisorRepository = advisorRepository;
        }

        public async Task AddAdvisor(AdvisorDTO advisor)
        {
            await _advisorRepository.AddAdvisor(advisor);
        }

        public Advisor GetAdvisorById(string advisorId)
        {
          return _advisorRepository.GetAdvisorById(advisorId);
        }

        public IEnumerable<Advisor> GetAll()
        {
            var advisors = _advisorRepository.GetAll();
            return advisors;
        }

        public async Task RemoveAdvisor(string advisorId)
        {
            await _advisorRepository.RemoveAdvisor(advisorId);
        }

        public async Task UpdateAdvisor(AdvisorDTO advisorUpdated)
        {
            await _advisorRepository.UpdateAdvisor(advisorUpdated);
        }
    }
}


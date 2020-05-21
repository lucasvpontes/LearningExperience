using LearningExperience.Models;
using LearningExperience.Repository;
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

        public async Task AddAdvisor(Advisor advisor)
        {
            await _advisorRepository.AddAdvisor(advisor);
        }

        public IEnumerable<Advisor> GetAll()
        {
            var advisors = _advisorRepository.GetAll();
            return advisors;
        }

        public async Task RemoveAdvisor(Advisor advisorRemoved)
        {
            await _advisorRepository.RemoveAdvisor(advisorRemoved);
        }

        public async Task UpdateAdvisor(Advisor advisorUpdated)
        {
            await _advisorRepository.UpdateAdvisor(advisorUpdated);
        }

        public async Task UpdateMultipleAdvisors(List<Advisor> advisorsUpdated)
        {
            await _advisorRepository.UpdateMultipleAdvisors(advisorsUpdated);
        }
    }
}


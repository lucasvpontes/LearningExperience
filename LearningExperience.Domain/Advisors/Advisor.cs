using LearningExperience.Application.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace LearningExperience.Domain.Advisors
{
    public class Advisor: IAdvisor
    {
        private readonly IAdvisorRepository _advisorRepository;

        public Advisor(IAdvisorRepository advisorRepository)
        {
            _advisorRepository = advisorRepository;
        }

        public async Task AddAdvisor(AdvisorDto advisor)
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

        public async Task RemoveAdvisor(AdvisorDto advisorRemoved)
        {
            await _advisorRepository.RemoveAdvisor(advisorRemoved);
        }

        public async Task UpdateAdvisor(AdvisorDto advisorUpdated)
        {
            await _advisorRepository.UpdateAdvisor(advisorUpdated);
        }
    }
}


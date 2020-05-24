using LearningExperience.Models;
using LearningExperience.Models.DTO;
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

        public async Task AddAdvisor(AdvisorDTO advisor)
        {
            await _advisorRepository.AddAdvisor(advisor);
        }

        public IEnumerable<Advisor> GetAll()
        {
            var advisors = _advisorRepository.GetAll();
            return advisors;
        }

        public async Task RemoveAdvisor(AdvisorDTO advisorRemoved)
        {
            await _advisorRepository.RemoveAdvisor(advisorRemoved);
        }

        public async Task UpdateAdvisor(AdvisorDTO advisorUpdated)
        {
            await _advisorRepository.UpdateAdvisor(advisorUpdated);
        }
    }
}


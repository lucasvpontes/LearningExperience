using LearningExperience.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningExperience.Services
{
    public interface IAdvisorService
    {
        Task AddAdvisor(Advisor advisor);
        IEnumerable<Advisor> GetAll();
        Task RemoveAdvisor(Advisor advisorRemoved);
        Task UpdateAdvisor(Advisor advisorUpdated);
        Task UpdateMultipleAdvisors(List<Advisor> advisorsUpdated);
    }
}


using LearningExperience.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningExperience.Repository
{
    public interface IAdvisorRepository
    {
        Task AddAdvisor(Advisor advisor);
        IEnumerable<Advisor> GetAll();
        Task RemoveAdvisor(Advisor advisorRemoved);
        Task UpdateAdvisor(Advisor advisorRemoved);
        Task UpdateMultipleAdvisors(Advisor advisorRemoved);
    }
}


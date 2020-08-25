using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningExperience.Application.Queries
{
    public interface IAdvisorQueries
    {
        Task AddAdvisor(AdvisorDto advisor);
        IEnumerable<Advisor> GetAll();
        Task RemoveAdvisor(AdvisorDto advisorRemoved);
        Task UpdateAdvisor(AdvisorDto advisorUpdated);
        Advisor GetAdvisorById(string AdvisorId);
    }
}


using LearningExperience.Models;
using LearningExperience.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningExperience.Services
{
    public interface IAdvisorService
    {
        Task AddAdvisor(AdvisorDto advisor);
        IEnumerable<Advisor> GetAll();
        Task RemoveAdvisor(AdvisorDto advisorRemoved);
        Task UpdateAdvisor(AdvisorDto advisorUpdated);
        Advisor GetAdvisorById(string AdvisorId);
    }
}


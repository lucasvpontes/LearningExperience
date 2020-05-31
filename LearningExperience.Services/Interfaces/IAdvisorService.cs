using LearningExperience.Models;
using LearningExperience.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningExperience.Services
{
    public interface IAdvisorService
    {
        Task AddAdvisor(AdvisorDTO advisor);
        IEnumerable<Advisor> GetAll();
        Task RemoveAdvisor(AdvisorDTO advisorRemoved);
        Task UpdateAdvisor(AdvisorDTO advisorUpdated);
        Advisor GetAdvisorById(string AdvisorId);
    }
}


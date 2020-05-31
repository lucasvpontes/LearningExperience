using LearningExperience.Models;
using LearningExperience.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningExperience.Repository
{
    public interface IAdvisorRepository
    {
        Task AddAdvisor(AdvisorDTO advisor);
        IEnumerable<Advisor> GetAll();
        Task RemoveAdvisor(AdvisorDTO advisorRemoved);
        Task UpdateAdvisor(AdvisorDTO advisorUpdated);
        Advisor GetAdvisorById(string advisorId);
    }
}


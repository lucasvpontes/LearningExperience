using LearningExperience.Models.Enums;
using LearningExperience.Models.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningExperience.Repository.Interfaces
{
    public interface IReportRepository
    {
        List<AsyncXRay> GetReportProgressByModule(string userId);
        List<AsyncXRay> GetReportProgressByMonth(string userId);
        List<AsyncXRay> GetReportProgressByMatches(string userId);
    }
}

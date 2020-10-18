using LearningExperience.Models.Enums;
using LearningExperience.Models.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningExperience.Services.Interfaces
{
    public interface IReportService
    {
        List<AsyncXRay> GetReportProgressByModule(string userId);
        List<AsyncXRay> GetReportProgressByMonth(string userId);
        List<ReportData> GetReportProgressByMatches(string userId);
    }
}

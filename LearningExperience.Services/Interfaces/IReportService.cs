using LearningExperience.Models.DTO;
using LearningExperience.Models.Model;
using System.Collections.Generic;

namespace LearningExperience.Services.Interfaces
{
    public interface IReportService
    {
        List<ReportByModuleResultDTO> GetReportProgressByModule(string userId);
        List<ReportByMonthResultDTO> GetReportProgressByMonth(string userId);
        List<ReportData> GetReportProgressByMatches(string userId);
    }
}

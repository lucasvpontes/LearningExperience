using LearningExperience.Models.Enums;
using LearningExperience.Models.Model;
using LearningExperience.Repository.Interfaces;
using LearningExperience.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningExperience.Services
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;

        public ReportService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public List<ReportData> GetReportProgressByMatches(string userId)
        {
            var result = _reportRepository.GetReportProgressByMatches(userId);
            var filteredResult = result.GroupBy(x => x.Action)
                                     .Select(grp => grp.ToList()).ToList();

            var dataResult = new List<ReportData>();

            foreach (List<AsyncXRay> reportData in filteredResult)
            {
                var data = new ReportData() {
                    Label = reportData.First().Action.ToString(), //TODO: Adicionar description nesse enum
                    Action = reportData.First().Action,
                    Count = reportData.Count()
               };

                dataResult.Add(data);  
            }

            return dataResult;
        }

        public List<ReportData> GetReportProgressByModule(string userId)
        {
            var result = _reportRepository.GetReportProgressByMatches(userId);
            var filteredResult = result.GroupBy(x => new { x.GameLevelType, x.Action})
                                       .Select(grp => grp.ToList()).ToList();

            var dataResult = new List<ReportData>();

            foreach (List<AsyncXRay> reportData in filteredResult)
            {
                var data = new ReportData()
                {
                    Label = reportData.First().Action.ToString(), //TODO: Adicionar description nesse enum
                    Action = reportData.First().Action,
                    Count = reportData.Count(),
                    GameLevelType = reportData.First().GameLevelType
                };

                dataResult.Add(data);
            }

            return dataResult;
        }

        public List<ReportData> GetReportProgressByMonth(string userId)
        {
            var result = _reportRepository.GetReportProgressByMatches(userId);
            var filteredResult = result.GroupBy(x => x.Action)
                                     .Select(grp => grp.ToList()).ToList();

            var dataResult = new List<ReportData>();

            foreach (List<AsyncXRay> reportData in filteredResult)
            {
                var data = new ReportData()
                {
                    Label = reportData.First().Action.ToString(), //TODO: Adicionar description nesse enum
                    Action = reportData.First().Action,
                    Count = reportData.Count(),
                    GameLevelType = reportData.First().GameLevelType
                };

                dataResult.Add(data);
            }

            return dataResult;
        }
    }
}

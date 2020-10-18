using LearningExperience.Models.DTO;
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

        public List<ReportByModuleResultDTO> GetReportProgressByModule(string userId)
        {
            var result = _reportRepository.GetReportProgressByModule(userId);
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
            var reportRightResult = new List<int>();
            var reportWrongResult = new List<int>();

            var orderedResult = dataResult.OrderBy(x => x.GameLevelType);

            foreach (ReportData matchesResult in orderedResult)
            {
                if(matchesResult.Action == AsyncAction.Acertos)
                {
                    reportRightResult.Add(matchesResult.Count);
                }
                else
                {
                    reportWrongResult.Add(matchesResult.Count);
                }
            };

            var moduleReportResult = new List<ReportByModuleResultDTO>();
            moduleReportResult.Add(new ReportByModuleResultDTO
            {
                Data = reportRightResult,
                Label = "Acertos"
            });
            moduleReportResult.Add(new ReportByModuleResultDTO
            {
                Data = reportWrongResult,
                Label = "Erros"
            });


            return moduleReportResult;
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

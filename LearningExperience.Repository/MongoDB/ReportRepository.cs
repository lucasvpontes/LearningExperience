using LearningExperience.Models.Enums;
using LearningExperience.Models.Model;
using LearningExperience.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningExperience.Repository.MongoDB
{
    public class ReportRepository : IReportRepository
    {
        private readonly IMongoRepository<AsyncXRay> _mongoRepository;
        public ReportRepository(IMongoRepository<AsyncXRay> mongoRepository)
        {
            _mongoRepository = mongoRepository;
        }

        public List<AsyncXRay> GetReportProgressByMatches(string userId)
        {
            var reportDataList = _mongoRepository.FilterBy(
            filter => filter.Deleted == false &&
                     filter.UserId == userId
            ).ToList();

            return reportDataList;
        }

        public List<AsyncXRay> GetReportProgressByModule(string userId)
        {
            var reportDataList = _mongoRepository.FilterBy(
            filter => filter.Deleted == false &&
                      filter.UserId == userId &&
                      filter.Action != AsyncAction.Reforçadores
            ).ToList();
            return reportDataList;
        }

        public List<AsyncXRay> GetReportProgressByMonth(string userId)
        {
            var reportDataList = _mongoRepository.FilterBy(
            filter => filter.Deleted == false &&
                      filter.UserId == userId
            ).ToList();

            return reportDataList;
        }
    }
}

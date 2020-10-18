using LearningExperience.Models.DTO;
using LearningExperience.Models.Enums;
using LearningExperience.Models.Model;
using LearningExperience.Models.Model.Interfaces;
using LearningExperience.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace LearningExperience.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("GetReportProgressByModule")]
        public List<ReportByModuleResultDTO> GetReportProgressByModule(string userId)
        {
            var reportResult = _reportService.GetReportProgressByModule(userId);
            return reportResult;
        }

        [HttpGet("GetReportProgressByMonth")]
        public List<ReportData> GetReportProgressByMonth(string userId)
        {
            var reportResult = _reportService.GetReportProgressByMonth(userId);
            return reportResult;
        }

        [HttpGet("GetReportProgressByMatches")]
        public List<ReportData> GetReportProgressByMatches(string userId)
        {
            var reportResult = _reportService.GetReportProgressByMatches(userId);
            return  reportResult;
        }
    }
}

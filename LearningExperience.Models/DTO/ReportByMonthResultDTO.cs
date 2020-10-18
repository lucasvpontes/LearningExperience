using LearningExperience.Models.Enums;

namespace LearningExperience.Models.DTO
{
    public class ReportByMonthResultDTO
    {
        public int Count { get; set; }
        public AsyncAction Action { get; set; }
        public string Label { get; set; }
    }
}

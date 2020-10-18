using LearningExperience.Models.Enums;

namespace LearningExperience.Models.Model
{
    public class ReportData
    {
        public int Count { get; set; }
        public AsyncAction Action { get; set; }
        public string Label { get; set; }
        public GameLevelType GameLevelType { get; set; }
    }
}

using LearningExperience.Models.Enums;

namespace LearningExperience.Models.DTO
{
    public class UserProgressResultDTO
    {
        public GameLevelType Module { get; set; }
        public double Progress { get; set; }
    }
}

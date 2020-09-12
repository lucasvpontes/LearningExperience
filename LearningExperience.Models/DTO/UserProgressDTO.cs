using LearningExperience.Models.Enums;

namespace LearningExperience.Models.DTO
{
    public class UserProgressDTO
    {
        public string UserId { get; set; }
        public GameLevelType Module { get; set; }
    }
}

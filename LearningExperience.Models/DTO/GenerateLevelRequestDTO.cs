using LearningExperience.Models.Enums;

namespace LearningExperience.Models.DTO
{
    public class GenerateLevelRequestDTO
    {
        public string Id { get; set; }
        public GameLevelType GameLevelType { get; set; }
    }
}

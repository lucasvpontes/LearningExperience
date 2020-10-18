using LearningExperience.Models.Enums;

namespace LearningExperience.Models.DTO
{
    public class AsyncXRayDTO
    {
        public string  UserId { get; set; }
        public AsyncAction Action { get; set; }
        public GameLevelType GameLevelType { get; set; }
    }
}

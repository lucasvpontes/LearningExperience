using LearningExperience.Models.Model;
using System.Collections.Generic;

namespace LearningExperience.Models.DTO
{
    public class GameLevelResult
    {
        public GameLevelImage MainImage { get; set; }
        public IList<GameLevelImage> Comparable { get; set; }
    }
}

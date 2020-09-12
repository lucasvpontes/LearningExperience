using LearningExperience.Models.DTO;
using LearningExperience.Models.Model.Interfaces;

namespace LearningExperience.Models.Model.ConcreteLevels
{
    public class EqualTwoDimensionalLevel : IGameLevel
    {
        public string catchPhrase { get; set; }

        public GameLevelResult Configure()
        {
            throw new System.NotImplementedException();
        }
    }
}

using LearningExperience.Models.DTO;
using LearningExperience.Models.Model.ConcreteLevels;
using LearningExperience.Models.Model.Interfaces;

namespace LearningExperience.Services.Factories.GameLevelGenerators
{
    public class EqualTwoAndThreeDimensionalLevelGenerator : GameLevelGenerator
    {
        public override IGameLevel GenerateLevelLogic(GenerateLevelRequestDTO gameLevelType)
        {
            var level = new ColorLevel()
            {
                catchPhrase = "And that's the wayyyyyy the news goes!"
            };

            return level;
        }
    }
}

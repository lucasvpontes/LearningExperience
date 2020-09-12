using LearningExperience.Models.DTO;
using LearningExperience.Models.Model.ConcreteLevels;
using LearningExperience.Models.Model.Interfaces;

namespace LearningExperience.Services.Factories.GameLevelGenerators
{
    public class EqualTwoDimensionalLevelGenerator : GameLevelGenerator
    {
        public override IGameLevel GenerateLevelLogic(GenerateLevelRequestDTO gameLevelType)
        {
            var gameLevel = new Shape2d();
            return gameLevel;
        }
    }
}

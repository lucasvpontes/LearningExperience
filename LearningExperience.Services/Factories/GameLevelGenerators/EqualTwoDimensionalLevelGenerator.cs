using LearningExperience.Models.DTO;
using LearningExperience.Models.Model.ConcreteLevels;
using LearningExperience.Models.Model.Interfaces;

namespace LearningExperience.Services.Factories.GameLevelGenerators
{
    public class EqualTwoDimensionalLevelGenerator : GameLevelGenerator
    {
        public override IGameLevel GenerateLevel()
        {
            return new EqualTwoDimensionalLevel();
        }
    }
}

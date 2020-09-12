using LearningExperience.Models.DTO;
using LearningExperience.Models.Model;
using LearningExperience.Models.Model.Interfaces;

namespace LearningExperience.Services.Factories.GameLevelGenerators
{
    public class EqualThreeDimensionalLevelGenerator : GameLevelGenerator
    {
        public override IGameLevel GenerateLevel()
        {
            return new EqualThreeDimensionalLevel();
        }
    }
}

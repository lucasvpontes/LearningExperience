using LearningExperience.Models.DTO;
using LearningExperience.Models.Model;
using LearningExperience.Models.Model.Interfaces;

namespace LearningExperience.Services.Factories.GameLevelGenerators
{
    public class EqualThreeDimensionalLevelGenerator : GameLevelGenerator
    {
        public override IGameLevel GenerateLevelLogic(GenerateLevelRequestDTO gameLevelType)
        {
            return new Shape3d();
        }
    }
}

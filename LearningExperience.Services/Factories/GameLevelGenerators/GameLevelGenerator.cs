using LearningExperience.Models.DTO;
using LearningExperience.Models.Model;
using LearningExperience.Models.Model.Interfaces;
using System.Collections.Generic;

namespace LearningExperience.Services.Factories.GameLevelGenerators
{
    public abstract class GameLevelGenerator
    {
        public abstract IGameLevel GenerateLevel();

        public GameLevelResult ConfigureLevelLogic(IList<GameLevelImage> gameLevelImages)
        {
            var level = GenerateLevel();
            var result = level.Configure(gameLevelImages);
            return result;
        }
    }
}

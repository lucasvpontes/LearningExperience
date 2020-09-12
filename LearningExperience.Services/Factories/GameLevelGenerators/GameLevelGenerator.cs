using LearningExperience.Models.DTO;
using LearningExperience.Models.Model.Interfaces;
using System.Collections.Generic;

namespace LearningExperience.Services.Factories.GameLevelGenerators
{
    public abstract class GameLevelGenerator
    {
        public abstract IGameLevel GenerateLevelLogic(GenerateLevelRequestDTO gameLevelType);
    }
}

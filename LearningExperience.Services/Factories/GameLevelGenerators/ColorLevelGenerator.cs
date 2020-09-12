using LearningExperience.Models.DTO;
using LearningExperience.Models.Model.ConcreteLevels;
using LearningExperience.Models.Model.Interfaces;
using System;

namespace LearningExperience.Services.Factories.GameLevelGenerators
{
    public class ColorLevelGenerator : GameLevelGenerator
    {
        public override IGameLevel GenerateLevel()
        {
            return new ColorLevel();
        }
    }
}

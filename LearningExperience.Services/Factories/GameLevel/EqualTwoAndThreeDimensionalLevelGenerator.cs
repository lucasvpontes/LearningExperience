using LearningExperience.Models.Model;
using LearningExperience.Models.Model.Interfaces;
using System;

namespace LearningExperience.Services.Factories.GameLevel
{
    public class EqualTwoAndThreeDimensionalLevelGenerator : GameLevelGenerator
    {
        public override IGameLevel GenerateLevel()
        {
            return new ColorLevel()
            {
                catchPhrase = "And that's the wayyyyyy the news goes!"
            };
        }
    }
}

﻿using LearningExperience.Models.Model;
using LearningExperience.Models.Model.Interfaces;

namespace LearningExperience.Services.Factories.GameLevel
{
    public class EqualThreeDimensionalLevelGenerator : GameLevelGenerator
    {
        public override IGameLevel GenerateLevel()
        {
            return new Shape3d();
        }
    }
}
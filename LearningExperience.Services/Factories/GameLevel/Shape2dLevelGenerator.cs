using LearningExperience.Models.Model;
using LearningExperience.Models.Model.Interfaces;

namespace LearningExperience.Services.Factories.GameLevel
{
    public class Shape2dLevelGenerator : GameLevelGenerator
    {
        public override IGameLevel GenerateLevel()
        {
            return new Shape2d();
        }
    }
}

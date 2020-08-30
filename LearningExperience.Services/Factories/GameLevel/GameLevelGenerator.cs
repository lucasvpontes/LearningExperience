using LearningExperience.Models.Model.Interfaces;

namespace LearningExperience.Services.Factories.GameLevel
{
    public abstract class GameLevelGenerator
    {
        public abstract IGameLevel GenerateLevel();

        public IGameLevel red ()
        {
            var match = GenerateLevel();

            //var result = match.
            return null;
        }
    }
}

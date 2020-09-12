using LearningExperience.Services.Factories.GameLevelGenerators;
using System;

namespace LearningExperience.Services.Factories
{
    public class GameLevelFactory
    {
        public void ClientCode(GameLevelGenerator levelGenerator)
        {
            Console.WriteLine("That's just a test.\n" + levelGenerator.GenerateLevelLogic());
        }
    }
}

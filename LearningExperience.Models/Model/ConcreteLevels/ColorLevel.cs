using LearningExperience.Models.DTO;
using LearningExperience.Models.Model.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace LearningExperience.Models.Model.ConcreteLevels
{
    public class ColorLevel : GameLevel
    {
        public override GameLevelResult Configure(IList<GameLevelImage> gameLevelImages)
        {
            IList<GameLevelImage> shuffledList = Shuffle(gameLevelImages).Take(6).ToList();
            shuffledList.First().Match = true;

            GameLevelResult gameLevelResult = new GameLevelResult()
            {
                MainImage = shuffledList.First(),
                Comparable = shuffledList
            };

            gameLevelResult.Comparable = Shuffle(gameLevelResult.Comparable);
            return gameLevelResult;
        }
    }
}

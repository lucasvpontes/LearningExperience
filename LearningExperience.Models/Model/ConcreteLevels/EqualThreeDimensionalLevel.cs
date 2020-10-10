using LearningExperience.Models.DTO;
using LearningExperience.Models.Model.ConcreteLevels;
using System.Collections.Generic;
using System.Linq;

namespace LearningExperience.Models.Model
{
    public class EqualThreeDimensionalLevel : GameLevel
    {
        public override GameLevelResult Configure(IList<GameLevelImage> gameLevelImages)
        {

            IList<GameLevelImage> shuffledList = Shuffle(gameLevelImages).Take(4).ToList();
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

using LearningExperience.Models.DTO;
using System.Collections.Generic;
using System.Linq;

namespace LearningExperience.Models.Model.ConcreteLevels
{
    public class AssociatedLevel : GameLevel
    {
        public override GameLevelResult Configure(IList<GameLevelImage> gameLevelImages)
        {
            IList<GameLevelImage> shuffledList = Shuffle(gameLevelImages).ToList();

            var comparebleMain = shuffledList.First();
            shuffledList.First().Match = true;
            var exernalId = shuffledList.First().ExternalId;
            var comparable = shuffledList.Single(s => s.Id == exernalId);
            comparable.Match = true;

            shuffledList = Shuffle(shuffledList).Where(s => s.Id != comparebleMain.Id && 
                                                       s.Id != comparable.Id)
                                                .Take(3).ToList();
            
            shuffledList.Add(comparable);

            GameLevelResult gameLevelResult = new GameLevelResult()
            {
                MainImage = comparebleMain,
                Comparable = shuffledList
            };

            gameLevelResult.Comparable = Shuffle(gameLevelResult.Comparable);
            return gameLevelResult;
        }
    }
}

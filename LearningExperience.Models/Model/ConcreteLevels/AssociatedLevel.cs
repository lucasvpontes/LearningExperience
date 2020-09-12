using LearningExperience.Models.DTO;
using LearningExperience.Models.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LearningExperience.Models.Model.ConcreteLevels
{
    public class AssociatedLevel : IGameLevel
    {
        public GameLevelResult Configure(IList<GameLevelImage> gameLevelImages)
        {
            IList<GameLevelImage> shuffledList = Shuffle(gameLevelImages);
            shuffledList.First().Match = true;

            GameLevelResult gameLevelResult = new GameLevelResult()
            {
                MainImage = shuffledList.First(),
                Comparable = shuffledList
            };

            gameLevelResult.Comparable = Shuffle(gameLevelResult.Comparable);
            return gameLevelResult;
        }

        public IList<GameLevelImage> Shuffle(IList<GameLevelImage> gameLevelImages)
        {
            return gameLevelImages.OrderBy(x => Guid.NewGuid()).ToList();
        }
    }
}

using LearningExperience.Models.DTO;
using LearningExperience.Models.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LearningExperience.Models.Model.ConcreteLevels
{
    public abstract class GameLevel: IGameLevel
    {
        public abstract GameLevelResult Configure(IList<GameLevelImage> gameLevelImages);

        public IList<GameLevelImage> Shuffle(IList<GameLevelImage> gameLevelImages)
        {
            return gameLevelImages.OrderBy(x => Guid.NewGuid()).ToList();
        }
    }
}

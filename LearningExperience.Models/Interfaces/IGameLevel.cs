using LearningExperience.Models.DTO;
using System.Collections.Generic;

namespace LearningExperience.Models.Model.Interfaces
{
    public interface IGameLevel
    {
        GameLevelResult Configure(IList<GameLevelImage> gameLevelImages);
        IList<GameLevelImage> Shuffle(IList<GameLevelImage> gameLevelImages);
    }
}

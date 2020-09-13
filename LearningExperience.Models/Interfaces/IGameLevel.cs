using LearningExperience.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LearningExperience.Models.Model.Interfaces
{
    public interface IGameLevel
    {
        GameLevelResult Configure(IList<GameLevelImage> gameLevelImages);
    }
}

using LearningExperience.Models.DTO;
using LearningExperience.Models.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningExperience.Services.Interfaces
{
    public interface IGameLevelService
    {
        Task RegisterImage(RegisterImageRequestDTO requestDTO);
        Task RemoveImage(string imageId);
        IList<GameLevel> GenerateLevel(GenerateLevelRequestDTO gameLevelType);
    }
}

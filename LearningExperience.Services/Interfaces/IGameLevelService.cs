using LearningExperience.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningExperience.Services.Interfaces
{
    public interface IGameLevelService
    {
        Task RegisterImage(RegisterImageRequestDTO requestDTO);
        Task RemoveImage(string imageId);
        GameLevelResult GenerateLevel(GenerateLevelRequestDTO gameLevelType);
        Task CreateAsyncXRay(AsyncXRayDTO xray);
    }
}

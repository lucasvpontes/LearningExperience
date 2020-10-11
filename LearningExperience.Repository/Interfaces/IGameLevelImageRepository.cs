using LearningExperience.Models.DTO;
using LearningExperience.Models.Enums;
using LearningExperience.Models.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningExperience.Repository.Interfaces
{
    public interface IGameLevelImageRepository
    {
        Task RegisterImage(RegisterImageRequestDTO request);
        Task RemoveImage(string imageId);
        IList<GameLevelImage> GetImagesByModule(GameLevelType type);
        Task CreateAsyncXRay(AsyncXRayDTO xray);
    }
}

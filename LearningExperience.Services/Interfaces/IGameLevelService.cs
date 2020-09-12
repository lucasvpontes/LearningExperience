using LearningExperience.Models.DTO;
using LearningExperience.Models.Model.Interfaces;
using System.Threading.Tasks;

namespace LearningExperience.Services.Interfaces
{
    public interface IGameLevelService
    {
        Task RegisterImage(RegisterImageRequestDTO requestDTO);
        Task RemoveImage(string imageId);
        GameLevelResult GenerateLevel(GenerateLevelRequestDTO gameLevelType);
    }
}

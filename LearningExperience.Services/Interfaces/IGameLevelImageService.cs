using LearningExperience.Models.DTO;
using System.Threading.Tasks;

namespace LearningExperience.Services.Interfaces
{
    public interface IGameLevelImageService
    {
        Task RegisterImage(RegisterImageRequestDTO requestDTO);
        Task RemoveImage(string imageId);
    }
}

using LearningExperience.Models.DTO;
using LearningExperience.Models.Model;
using System.Threading.Tasks;

namespace LearningExperience.Repository.Interfaces
{
    public interface IGameLevelImageRepository
    {
        Task RegisterImage(RegisterImageRequestDTO request);
        Task RemoveImage(string imageId);
    }
}

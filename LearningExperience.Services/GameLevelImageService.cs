using LearningExperience.Models.DTO;
using LearningExperience.Repository.Interfaces;
using LearningExperience.Services.Interfaces;
using System.Threading.Tasks;

namespace LearningExperience.Services
{
    public class GameLevelImageService : IGameLevelImageService
    {
        private readonly IGameLevelImageRepository _gameLevelImageRepository;

        public GameLevelImageService(IGameLevelImageRepository advisorRepository)
        {
            _gameLevelImageRepository = advisorRepository;
        }

        public async Task RegisterImage(RegisterImageRequestDTO requestDTO)
        {
            await _gameLevelImageRepository.RegisterImage(requestDTO);
        }

        public async Task RemoveImage(string imageId)
        {
            await _gameLevelImageRepository.RemoveImage(imageId);
        }
    }
}
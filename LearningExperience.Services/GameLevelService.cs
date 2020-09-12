using LearningExperience.Models.DTO;
using LearningExperience.Models.Model.Interfaces;
using LearningExperience.Repository.Interfaces;
using LearningExperience.Services.Factories.GameLevelGenerators;
using LearningExperience.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace LearningExperience.Services
{
    public class GameLevelService : IGameLevelService
    {
        private readonly IGameLevelImageRepository _gameLevelRepository;

        public GameLevelService(IGameLevelImageRepository gameLevelRepository)
        {
            _gameLevelRepository = gameLevelRepository;

        }

        public GameLevelResult GenerateLevel(GenerateLevelRequestDTO gameLevelType)
        {
            var gameLevel = GetLevel(gameLevelType);
            var images = _gameLevelRepository.GetAll();
            var options = gameLevel.ConfigureLevelLogic(images);
            return options;
        }

        public GameLevelGenerator GetLevel(GenerateLevelRequestDTO generateLevelRequest)
        {

            try
            {
                var gameLevelType = generateLevelRequest.GameLevelType;
                var ns = "LearningExperience.Services.Factories.GameLevelGenerators";
                var typeName = ns + "." + gameLevelType.ToString();
                var type = Type.GetType(typeName);
                var gameLevel = (GameLevelGenerator)Activator.CreateInstance(type);
                return gameLevel;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task RegisterImage(RegisterImageRequestDTO requestDTO)
        {
            await _gameLevelRepository.RegisterImage(requestDTO);
        }

        public async Task RemoveImage(string imageId)
        {
            await _gameLevelRepository.RemoveImage(imageId);
        }
    }
}
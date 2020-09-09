using LearningExperience.Models.DTO;
using LearningExperience.Models.Model;
using LearningExperience.Repository.Interfaces;
using LearningExperience.Services.Factories.GameLevel;
using LearningExperience.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningExperience.Services
{
    public class GameLevelService : IGameLevelService
    {
        private readonly IGameLevelImageRepository _gameLevelImageRepository;

        public GameLevelService(IGameLevelImageRepository advisorRepository)
        {
            _gameLevelImageRepository = advisorRepository;
        }

        public IList<GameLevel> GenerateLevel(GenerateLevelRequestDTO gameLevelType)
        {
            var gameLevel = GetLevel(gameLevelType);
            Console.WriteLine(gameLevel.GenerateLevel());
            return null;
        }

        public GameLevelGenerator GetLevel(GenerateLevelRequestDTO generateLevelRequest)
        {

            try
            {
                var gameLevelType = generateLevelRequest.GameLevelType;
                var ns = "LearningExperience.Services.Factories.GameLevel";
                var typeName = ns + "." + gameLevelType.ToString();
                var type = Type.GetType(typeName);
                var gameLevel = (GameLevelGenerator) Activator.CreateInstance(type);
                return gameLevel;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
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
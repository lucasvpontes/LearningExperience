using LearningExperience.Models.DTO;
using LearningExperience.Models.Enums;
using LearningExperience.Models.Model;
using LearningExperience.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningExperience.Repository.MongoDB
{
    public class GameLevelImageRepository : IGameLevelImageRepository
    {
        private readonly IMongoRepository<GameLevelImage> _mongoRepository;
        private readonly IMongoRepository<AsyncXRay> _xrayRepository;
        public GameLevelImageRepository(IMongoRepository<GameLevelImage> mongoRepository, IMongoRepository<AsyncXRay> xrayRepository)
        {
            _mongoRepository = mongoRepository;
            _xrayRepository = xrayRepository;
        }

        public async Task RegisterImage(RegisterImageRequestDTO request)
        {
            var image = new GameLevelImage()
            {
                Name = request.Name,
                GameLevelType = request.GameLevelType,
                Path = request.Path,
                ExternalId = request.ExternalId

            };
            await _mongoRepository.InsertOneAsync(image);
        }

        public async Task RemoveImage(string imageId)
        {
            await _mongoRepository.DeleteOneAsync(
               gameLevelImage => gameLevelImage.Id == imageId);
        }

        public IList<GameLevelImage> GetImagesByModule(GameLevelType type)
        {
            var gameLevelImages = _mongoRepository.FilterBy(
                filter => (filter.Deleted == false &&
                           filter.GameLevelType == type
            ));
            return gameLevelImages.ToList();
        }

        public async Task CreateAsyncXRay(AsyncXRayDTO xray)
        {
            var asyncXRay = new AsyncXRay()
            {
                UserId = xray.UserId,
                Action = xray.Action,
                GameLevelType = xray.GameLevelType
            };

            await _xrayRepository.InsertOneAsync(asyncXRay);
        }
    }
}

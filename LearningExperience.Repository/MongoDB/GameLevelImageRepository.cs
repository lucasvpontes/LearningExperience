using LearningExperience.Models.DTO;
using LearningExperience.Models.Model;
using System.Threading.Tasks;

namespace LearningExperience.Repository.MongoDB
{
    public class GameLevelImageRepository
    {
        private readonly IMongoRepository<GameLevelImage> _mongoRepository;
        public GameLevelImageRepository(IMongoRepository<GameLevelImage> mongoRepository)
        {
            _mongoRepository = mongoRepository;
        }

        public async Task AddGameLevelImage(RegisterImageRequestDTO request)
        {
            var image = new GameLevelImage()
            {
                Name = request.Name,
                GameModule = request.GameModule,
                Urn = request.Urn
                
            };
            await _mongoRepository.InsertOneAsync(image);
        } 

        public async Task RemoveGameLevelImage(string imageId)
        {
            await _mongoRepository.DeleteOneAsync(
               gameLevelImage => gameLevelImage.Id == imageId);
        }
    }
}

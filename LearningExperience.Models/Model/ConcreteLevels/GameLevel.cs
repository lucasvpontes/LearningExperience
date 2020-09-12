using LearningExperience.Models.Model.Interfaces;

namespace LearningExperience.Models.Model.ConcreteLevels
{
    public class GameLevel : IGameLevel
    {
        public int Progress { get; set; }
        public IGameLevel GenerateLevel()
        {
            throw new System.NotImplementedException();
        }
    }
}

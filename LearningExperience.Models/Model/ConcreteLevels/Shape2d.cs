using LearningExperience.Models.Model.Interfaces;

namespace LearningExperience.Models.Model.ConcreteLevels
{
    public class Shape2d : IGameLevel
    {
        public string catchPhrase { get; set; }

        public IGameLevel GenerateLevel()
        {
            throw new System.NotImplementedException();
        }
    }
}

using LearningExperience.Models.Model.Interfaces;

namespace LearningExperience.Models.Model
{
    public class Shape2d : IGameLevel
    {
        public string catchPhrase { get; set; }
        public IGameLevel GenerateLevel()
        {
            return null;
        }
    }
}

using LearningExperience.Models.Model;
using LearningExperience.Services.Interfaces;

namespace LearningExperience.Services.Factories
{
    abstract class LevelGameFactory
    {
        public abstract ILevelGame FactoryMethod();

        public GameLevel GerenateLevel()
        {
        
            
        }
    }
}

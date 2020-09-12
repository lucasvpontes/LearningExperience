using LearningExperience.Models.DTO;
using LearningExperience.Models.Model;
using System.Threading.Tasks;

namespace LearningExperience.Repository.Interfaces
{
    public interface IUserProgressRepository
    {
        Task UpdateUserProgress(UserProgressUpdateDTO userProgress);
        UserProgress GetUserProgress(UserProgressDTO userProgress);
    }
}

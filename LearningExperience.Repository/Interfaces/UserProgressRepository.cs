using LearningExperience.Models.DTO;
using LearningExperience.Models.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningExperience.Repository.Interfaces
{
    public interface IUserProgressRepository
    {
        Task UpdateUserProgress(UserProgressUpdateDTO userProgress);
        double GetProgressByModule(UserProgressDTO userProgress);
        IEnumerable<UserProgress> GetProgressByUser(string userId);
    }
}

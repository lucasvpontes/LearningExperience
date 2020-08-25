using System;

namespace LearningExperience.Api.UseCases.InactiveUser
{
    public class InactiveUserRequest
    {
        public User User { get; set; }
        public DateTime? RequestDate { get; set; }
    }
}
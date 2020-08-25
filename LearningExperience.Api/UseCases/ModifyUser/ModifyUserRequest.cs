using System;

namespace LearningExperience.Api.UseCases.ModifyPatient
{
    public class ModifyUserRequest
    {
        public User User { get; set; }
        public DateTime? RequestDate { get; set; }
    }
}
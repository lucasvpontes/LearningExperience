using System;

namespace LearningExperience.Models.DTO
{
    public class GetUserDetailsRequest
    {
        public User User { get; set; }
        public DateTime? RequestDate { get; set; }
    }
}
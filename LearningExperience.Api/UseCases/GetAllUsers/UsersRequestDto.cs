using System;
using System.Collections.Generic;

namespace LearningExperience.Models.DTO
{
    public class UsersRequestDto
    {
        public List<User> Users { get; set; }
        public DateTime? RequestDate { get; set; }
    }
}
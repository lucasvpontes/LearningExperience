using System;
using System.Collections.Generic;

namespace LearningExperience.Api.UseCases.GetAllUsers
{
    public class GetAllUsersRequest
    {
        public List<User> Users { get; set; }
        public DateTime? RequestDate { get; set; }
    }
}
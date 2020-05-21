using System;
using System.Collections.Generic;

namespace LearningExperience.Models.DTO
{
    public class AdvisorsRequestDTO
    {
        public List<Advisor> Advisors { get; set; }
        public DateTime? RequestDate { get; set; }
    }
}
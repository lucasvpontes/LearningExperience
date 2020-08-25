using System;
using System.Collections.Generic;

namespace LearningExperience.Api.UseCases.GetAllAdvisors
{
    public class GetAllAdvisorsRequest
    {
        public List<Advisor> Advisors { get; set; }
        public DateTime? RequestDate { get; set; }
    }
}
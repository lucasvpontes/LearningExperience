using Newtonsoft.Json;
using System;

namespace LearningExperience.Models.DTO
{
    public class AdvisorDTO
    {
        [JsonProperty("Advisor")]
        public Advisor Advisor { get; set; }
        public DateTime? RequestDate { get; set; }
    }
}
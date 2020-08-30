using LearningExperience.Models.Enums;
using System;

namespace LearningExperience.Models.DTO
{
    public class RegisterImageRequestDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Urn { get; set; }
        public Module GameModule { get; set; }
        public DateTime RequestDate { get; set; }
    }
}

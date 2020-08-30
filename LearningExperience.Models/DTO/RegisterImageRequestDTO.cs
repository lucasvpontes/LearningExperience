using LearningExperience.Models.Enums;
using System;

namespace LearningExperience.Models.DTO
{
    public class RegisterImageRequestDTO
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public Module Module { get; set; }
    }
}

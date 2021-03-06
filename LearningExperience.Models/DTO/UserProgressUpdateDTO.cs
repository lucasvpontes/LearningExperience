﻿using LearningExperience.Models.Enums;

namespace LearningExperience.Models.DTO
{
    public class UserProgressUpdateDTO
    {
        public string Id { get; set; }
        public GameLevelType Module { get; set; }
        public double Progress { get; set; }
    }
}

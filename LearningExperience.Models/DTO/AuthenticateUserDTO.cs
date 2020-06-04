using System;

namespace LearningExperience.Models.DTO
{
    public class AuthenticateUserDTO
    {
        public string? Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RepeatPassword { get; set; }
    }
}
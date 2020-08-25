using System;

namespace LearningExperience.Models.DTO
{
    public class SignInUserDto
    {
        public string? Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
using System;

namespace LearningExperience.Models.DTO
{
    public class UserDTO
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public UserDTO(User user)
        {
            Id = user.Id;
            Name = user.Name;
            Email = user.Email;
        }

        public UserDTO()
        {

        }
    }
}
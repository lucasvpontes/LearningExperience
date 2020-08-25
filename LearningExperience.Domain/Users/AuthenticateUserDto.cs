namespace LearningExperience.Domain.Users
{
    public class AuthenticateUserDto
    {
        public string? Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? RepeatPassword { get; set; }
    }
}
namespace LearningExperience.Models.DTO
{
    public class UserReturnDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public UserReturnDTO(User user)
        {
            Id = user.Id;
            Name = user.Name;
            Email = user.Email;
        }

        public UserReturnDTO()
        {

        }
    }
}

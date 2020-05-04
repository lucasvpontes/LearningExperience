namespace LearningExperience.Models
{
    public class Advisor : ModelBase
    {
        public string Profession { get; set; }
        public string Education { get; set; }
        public string Specialization { get; set; }
        public string? Comment { get; set; }
        public string? LastUpdate { get; set; }
    }
}

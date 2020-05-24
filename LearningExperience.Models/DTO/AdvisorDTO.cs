using System;

namespace LearningExperience.Models.DTO
{
    public class AdvisorDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Profession { get; set; }
        public string Education { get; set; }
        public string Specialization { get; set; }
        public string? Comment { get; set; }
        public string? LastUpdate { get; set; }
        public DateTime? RequestDate { get; set; }
    }
}
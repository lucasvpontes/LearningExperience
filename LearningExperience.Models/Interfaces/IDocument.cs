using System;

namespace LearningExperience.Models.Interfaces
{
    public interface IDocument
    {
        string Id { get; set; }
        string Name { get; set; }
        DateTime CreatedAt { get; set; }
        bool Deleted { get; set; }
    }
}

using System;

namespace LearningExperience.Models.Interfaces
{
    public interface IDocument
    {
        string Id { get; }
        string Name { get; set; }
        DateTime CreatedAt { get; }
        bool Deleted { get; set; }
    }
}

using LearningExperience.Models.Interfaces;
using System;

namespace LearningExperience.Models
{


    public abstract class Document : IDocument
    {
        public string Id => Guid.NewGuid().ToString();
        public string Name { get; set; }
        public DateTime CreatedAt => DateTime.Now;
        public bool Deleted { get; set; }
    }
}

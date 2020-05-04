namespace LearningExperience.Models
{
    public interface IModelRoot
    {
        string Id { get; set; }
    }

    public interface ISimpleModel: IModelRoot
    {
        string Name { get; set; }
        bool Deleted { get; set; }
    }
}

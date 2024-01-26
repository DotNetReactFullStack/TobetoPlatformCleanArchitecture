using Core.Persistence.Repositories;


namespace Domain.Entities;
public class LearningPathCategory : Entity<int>
{
    public string Name { get; set; }
    public bool IsActive { get; set; }

    public virtual ICollection<LearningPath> LearningPaths { get; set; }

    public LearningPathCategory()
    {

    }

    public LearningPathCategory(int id, string name, bool isActive) : this()
    {
        Id = id;
        Name = name;
        IsActive = isActive;
    }
}
using Core.Persistence.Repositories;

namespace Domain.Entities;

public class RecourseDetail : Entity<int>
{
    public string Name { get; set; }
    public string Priority { get; set; }
    public bool Visibility { get; set; }

    public virtual ICollection<AccountRecourseDetail> AccountRecourseDetails { get; set; }
    public RecourseDetail()
    {

    }

    public RecourseDetail(int id, string name, string priority, bool visibility) : this()
    {
        Id = id;
        Name = name;
        Priority = priority;
        Visibility = visibility;
    }
}
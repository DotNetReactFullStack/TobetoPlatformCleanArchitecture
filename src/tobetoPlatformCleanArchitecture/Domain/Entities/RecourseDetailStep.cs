using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class RecourseDetailStep : Entity<int>
{
    public string Name { get; set; }
    public string Priority { get; set; }
    public bool Visibility { get; set; }

    public virtual ICollection<AccountRecourseDetail> AccountRecourseDetails { get; set; }
    public RecourseDetailStep()
    {

    }

    public RecourseDetailStep(int id, string name, string priority, bool visibility) : this()
    {
        Id = id;
        Name = name;
        Priority = priority;
        Visibility = visibility;
    }
}
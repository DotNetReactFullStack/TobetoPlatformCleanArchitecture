using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class CourseCategory : Entity<int>
{
    public int Name { get; set; }
    public bool Visibility { get; set; }

    public CourseCategory()
    {
        
    }

    public CourseCategory(int name, bool visibility) : this()
    {
        Name = name;
        Visibility = visibility;
    }
}

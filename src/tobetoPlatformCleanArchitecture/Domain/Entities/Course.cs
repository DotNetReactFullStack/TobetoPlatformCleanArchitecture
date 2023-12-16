using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Course : Entity<int>
{
    public int CourseCategoryId { get; set; }
    public string Name { get; set; }
    public int Priority { get; set; }

    public Course()
    {
        
    }

    public Course(int id, int courseCategoryId, string name, int priority) : this()
    {
        Id = id;
        CourseCategoryId = courseCategoryId;
        Name = name;
        Priority = priority;
    }
}

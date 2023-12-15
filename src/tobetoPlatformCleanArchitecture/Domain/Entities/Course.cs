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

    public Course()
    {
        
    }

    public Course(int courseCategoryId, string name) : this()
    {
        CourseCategoryId = courseCategoryId;
        Name = name;
    }
}

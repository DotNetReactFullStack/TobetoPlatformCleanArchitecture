using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class CoursePath : Entity<int>
{
    public int CourseId { get; set; }
    public int PathId { get; set; }

    public CoursePath()
    {
        
    }

    public CoursePath(int courseId, int pathId) : this()
    {
        CourseId = courseId;
        PathId = pathId;
    }
}

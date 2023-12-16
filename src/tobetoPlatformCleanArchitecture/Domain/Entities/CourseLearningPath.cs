using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class CourseLearningPath : Entity<int>
{
    public int CourseId { get; set; }
    public int PathId { get; set; }
    public bool Visibility { get; set; }

    public CourseLearningPath()
    {

    }

    public CourseLearningPath(int id, int courseId, int pathId, bool visibility) : this()
    {
        Id = id;
        CourseId = courseId;
        PathId = pathId;
        Visibility = visibility;
    }
}

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
    public int LearningPathId { get; set; }
    public bool Visibility { get; set; }

    public virtual Course? Course { get; set; }
    public virtual LearningPath? LearningPath { get; set; }

    public CourseLearningPath()
    {

    }

    public CourseLearningPath(int id, int courseId, int learningPathId, bool visibility) : this()
    {
        Id = id;
        CourseId = courseId;
        LearningPathId = learningPathId;
        Visibility = visibility;
    }
}

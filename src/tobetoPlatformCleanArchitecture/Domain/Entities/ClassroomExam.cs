using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class ClassroomExam : Entity<int>
{
    public int ClassroomId { get; set; }
    public int ExamId { get; set; }
    public bool IsActive { get; set; }

    public virtual Classroom? Classroom { get; set; }
    public virtual Exam? Exam { get; set; }

    public ClassroomExam()
    {
    }

    public ClassroomExam(int id, int classroomId, int examId, bool isActive):this()
    {
        Id = id;
        ClassroomId = classroomId;
        ExamId = examId;
        IsActive = isActive;
    }
}

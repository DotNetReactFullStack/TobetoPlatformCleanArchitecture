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

    public ClassroomExam()
    {
    }

    public ClassroomExam(int classId, int examId, bool ısActive):this()
    {
        ClassroomId = classId;
        ExamId = examId;
        IsActive = ısActive;
    }
}

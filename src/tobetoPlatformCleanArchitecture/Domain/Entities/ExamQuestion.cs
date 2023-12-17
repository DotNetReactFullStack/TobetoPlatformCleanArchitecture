using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class ExamQuestion : Entity<int>
{
    public int ExamId { get; set; }
    public int QuestionId { get; set; }
   
    public virtual Exam? Exam { get; set; }
    public virtual Question? Question { get; set; }

    public ExamQuestion()
    {
        
    }

    public ExamQuestion(int id, int examId, int questionId) : this()
    {
        Id = id;
        ExamId = examId;
        QuestionId = questionId;
    }
}

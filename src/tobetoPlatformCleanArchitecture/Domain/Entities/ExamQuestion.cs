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


    public ExamQuestion()
    {
        
    }

    public ExamQuestion(int examId, int questionId) : this()
    {
        ExamId = examId;
        QuestionId = questionId;
    }
}

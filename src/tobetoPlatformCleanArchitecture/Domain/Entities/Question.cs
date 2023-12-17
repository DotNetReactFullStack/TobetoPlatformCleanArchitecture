using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Question : Entity<int>
{
    public int QuestionCategoryId { get; set; }
    public string QuestionDetail { get; set; }
    public bool IsActive { get; set; }

    public virtual QuestionCategory? QuestionCategory { get; set; }
    public virtual ICollection<ExamQuestion> ExamQuestions { get; set; }
    public virtual ICollection<Answer> Answers { get; set; }

    public Question()
    {
        
    }

    public Question(int id, int questionCategoryId, string questionDetail, bool isActive) : this()
    {
        Id = id;
        QuestionCategoryId = questionCategoryId;
        QuestionDetail = questionDetail;
        IsActive = isActive;
    }
}

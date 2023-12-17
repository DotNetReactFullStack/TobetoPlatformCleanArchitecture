using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Answer : Entity<int>
{
    public int QuestionId { get; set; }
    public string AnswerDetail { get; set; }
    public bool RightAnswerBool { get; set; }

    public virtual Question? Question { get; set; }

    public Answer()
    {
        
    }

    public Answer(int id, int questionId, string answerDetail, bool rightAnswerBool) : this()
    {
        Id = id;
        QuestionId = questionId;
        AnswerDetail = answerDetail;
        RightAnswerBool = rightAnswerBool;
    }
}

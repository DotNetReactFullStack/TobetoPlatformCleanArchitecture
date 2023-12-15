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


    public Question()
    {
        
    }

    public Question(int questionCategoryId, string questionDetail, bool ısActive) : this()
    {
        QuestionCategoryId = questionCategoryId;
        QuestionDetail = questionDetail;
        IsActive = ısActive;
    }
}

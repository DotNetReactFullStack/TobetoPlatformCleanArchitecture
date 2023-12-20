using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class AccountLesson : Entity<int>
{
    public int LessonId { get; set; }
    public int AccountId { get; set; }
    public int Points { get; set; }
    public bool IsComplete { get; set; }

    public virtual Lesson? Lesson { get; set; }
    public virtual Account? Account { get; set; }

    public AccountLesson()
    {
        
    }

    public AccountLesson(int id, int lessonId, int accountId, int points, bool isComplete) : this()
    {
        Id = id;
        LessonId = lessonId;
        AccountId = accountId;
        Points = points;
        IsComplete = isComplete;
    }
}

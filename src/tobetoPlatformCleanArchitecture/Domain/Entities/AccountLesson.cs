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
    public bool IsCompleted { get; set; }


    public AccountLesson()
    {
        
    }

    public AccountLesson(int lessonId, int accountId, int points, bool ısCompleted) : this()
    {
        LessonId = lessonId;
        AccountId = accountId;
        Points = points;
        IsCompleted = ısCompleted;
    }
}

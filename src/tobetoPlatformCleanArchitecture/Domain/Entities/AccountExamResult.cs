using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class AccountExamResult : Entity<int>
{
    public int AccountId { get; set; }
    public int ExamId { get; set; }
    public bool Visibility { get; set; }
    public int NumberOfRightAnswers { get; set; }
    public int NumberOfWrongAnswers { get; set; }
    public int NumberOfNullAnswers { get; set; }
    public int Points { get; set; }

    public virtual Account? Account { get; set; }
    public virtual Exam? Exam { get; set; }

    public AccountExamResult()
    {
        
    }

    public AccountExamResult(int id, int accountId, int examId, bool visibility, int numberOfRightAnswers, int numberOfWrongAnswers, int numberOfNullAnswers, int points):this()
    {
        Id = id;
        AccountId = accountId;
        ExamId = examId;
        Visibility = visibility;
        NumberOfRightAnswers = numberOfRightAnswers;
        NumberOfWrongAnswers = numberOfWrongAnswers;
        NumberOfNullAnswers = numberOfNullAnswers;
        Points = points;
    }
}

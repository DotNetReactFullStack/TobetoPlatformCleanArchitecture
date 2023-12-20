using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class AccountLearningPath : Entity<int>
{
    public int AccountId { get; set; }
    public int LearningPathId { get; set; }
    public int TotalNumberOfPoints { get; set; }
    public byte PercentComplete { get; set; }
    public bool IsContinue { get; set; }
    public bool IsComplete { get; set; }
    public bool IsLiked { get; set; }
    public bool IsSaved { get; set; }
    public bool IsActive { get; set; }

    public virtual Account? Account { get; set; }
    public virtual LearningPath? LearningPath { get; set; }


    public AccountLearningPath()
    {

    }

    public AccountLearningPath(int id, int accountId, int learningPathId, int totalNumberOfPoints, byte percentComplete, bool isContinue, bool isComplete, bool isLiked, bool isSaved, bool isActive) : this()
    {
        Id = id;
        AccountId = accountId;
        LearningPathId = learningPathId;
        TotalNumberOfPoints = totalNumberOfPoints;
        PercentComplete = percentComplete;
        IsContinue = isContinue;
        IsComplete = isComplete;
        IsLiked = isLiked;
        IsSaved = isSaved;
        IsActive = isActive;
    }
}

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
    public byte PercentCompleted { get; set; }

    public virtual Account? Account { get; set; }
    public virtual LearningPath? LearningPath { get; set; }


    public AccountLearningPath()
    {

    }

    public AccountLearningPath(int id, int accountId, int learningPathId, int totalNumberOfPoints, byte percentCompleted) : this()
    {
        Id = id;
        AccountId = accountId;
        LearningPathId = learningPathId;
        TotalNumberOfPoints = totalNumberOfPoints;
        PercentCompleted = percentCompleted;
    }
}

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
    public int PathId { get; set; }
    public int TotalNumberOfPoints { get; set; }
    public byte PercentCompleted { get; set; }


    public AccountLearningPath()
    {

    }

    public AccountLearningPath(int id, int accountId, int pathId, int totalNumberOfPoints, byte percentCompleted) : this()
    {
        Id = id;
        AccountId = accountId;
        PathId = pathId;
        TotalNumberOfPoints = totalNumberOfPoints;
        PercentCompleted = percentCompleted;
    }
}

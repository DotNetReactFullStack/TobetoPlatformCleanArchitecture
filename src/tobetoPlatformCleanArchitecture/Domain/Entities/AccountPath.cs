 using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class AccountPath : Entity<int>
{
    public int AccountId { get; set; }
    public int PathId { get; set; }
    public int TotalNumberOfPoints { get; set; }
    public byte PercentCompleted { get; set; }


    public AccountPath()
    {
        
    }

    public AccountPath(int accountId, int pathId, int totalNumberOfPoints, byte percentCompleted) : this()
    {
        AccountId = accountId;
        PathId = pathId;
        TotalNumberOfPoints = totalNumberOfPoints;
        PercentCompleted = percentCompleted;
    }
}

using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Domain.Entities;
public class AccountRecourse : Entity<int>
{
    public int AccountId { get; set; }
    public int RecourseId { get; set; }
    public int RecourseStepId { get; set; }

    public virtual Account? Account { get; set; } 
    public virtual Recourse? Recourse { get; set; } 
    public virtual RecourseStep? RecourseStep { get; set; } 

    public AccountRecourse()
    {
        
    }

    public AccountRecourse(int id, int accountId, int recourseId, int recourseStepId) : this()
    {
        Id = id;
        AccountId = accountId;
        RecourseId = recourseId;
        RecourseStepId = recourseStepId;
    }
}

using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class AccountApplication : Entity<int>
{
    public int AccountId { get; set; }
    public int ApplicationId { get; set; }
    public int ApplicationStepId { get; set; }

    public AccountApplication()
    {
        
    }

    public AccountApplication(int accountId, int applicationId, int applicationStepId) : this()
    {
        AccountId = accountId;
        ApplicationId = applicationId;
        ApplicationStepId = applicationStepId;
    }
}

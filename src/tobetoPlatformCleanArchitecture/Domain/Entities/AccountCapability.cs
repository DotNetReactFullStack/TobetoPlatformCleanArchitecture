using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class AccountCapability : Entity<int>
{
    public int AccountId { get; set; }
    public int CapabilityId { get; set; }
    public int Priority { get; set; }

    public virtual Account? Account { get; set; }
    public virtual Capability? Capability { get; set; }

    public AccountCapability()
    {
        
    }

    public AccountCapability(int id, int accountId, int capabilityId, int priority) : this()
    {
        Id = id;
        AccountId = accountId;
        CapabilityId = capabilityId;
        Priority = priority;
    }
}

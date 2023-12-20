using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class AccountClassroom : Entity<int>
{
    public int AccountId { get; set; }
    public int ClassroomId { get; set; }
    public bool IsActive { get; set; }

    public virtual Account? Account { get; set; }
    public virtual Classroom? Classroom { get; set; }

    public AccountClassroom()
    {
        
    }

    public AccountClassroom(int id, int accountId, int classroomId, bool isActive) : this()
    {
        Id = id;
        AccountId = accountId;
        ClassroomId = classroomId;
        IsActive = isActive;
    }
}

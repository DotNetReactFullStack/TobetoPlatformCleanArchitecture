using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class AccountCourse : Entity<int>
{
    public int CourseId { get; set; }
    public int AccountId { get; set; }
    public bool IsActive { get; set; }

    public virtual Course? Course { get; set; }
    public virtual Account? Account { get; set; }

    public AccountCourse()
    {
        
    }

    public AccountCourse(int id, int courseId, int accountId, bool isActive) : this()
    {
        Id = id;
        CourseId = courseId;
        AccountId = accountId;
        IsActive = isActive;
    }
}

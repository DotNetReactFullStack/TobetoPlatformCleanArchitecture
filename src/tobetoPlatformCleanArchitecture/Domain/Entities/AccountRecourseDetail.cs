using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class AccountRecourseDetail : Entity<int>
{
    public int AccountRecourseId { get; set; }
    public int RecourseDetailStepId { get; set; }
    public int RecourseDetailId { get; set; }

    public virtual AccountRecourse AccountRecourse { get; set; }
    public virtual RecourseDetailStep RecourseDetailStep { get; set; }
    public virtual RecourseDetail RecourseDetail { get; set; }


    public AccountRecourseDetail()
    {

    }

    public AccountRecourseDetail(int id, int accountRecourseId, int recourseDetailStepId, int recourseDetailId) : this()
    {
        Id = id;
        AccountRecourseId = accountRecourseId;
        RecourseDetailStepId = recourseDetailStepId;
        RecourseDetailId = recourseDetailId;
    }
}
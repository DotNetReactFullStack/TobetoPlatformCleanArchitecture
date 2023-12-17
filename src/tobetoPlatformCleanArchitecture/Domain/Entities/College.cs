using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class College : Entity<int>
{
    public string Name { get; set; }
    public bool Visibility { get; set; }

    public virtual ICollection<EducationProgram> EducationPrograms { get; set; }
    public virtual ICollection<AccountCollageMetadata> AccountCollageMetadatas { get; set; }

    public College()
    {
        
    }

    public College(int id, string name, bool visibility):this()
    {
        Id = id;
        Name = name;
        Visibility = visibility;
    }
}

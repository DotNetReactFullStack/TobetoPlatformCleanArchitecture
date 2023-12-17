using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class EducationProgram : Entity<int>
{
    public int CollegeId { get; set; }
    public string Name { get; set; }
    public bool Visibility { get; set; }

    public virtual College? College { get; set; }
    public virtual ICollection<AccountCollageMetadata> AccountCollageMetadatas { get; set; }

    public EducationProgram()
    {
        
    }

    public EducationProgram(int id, int collegeId, string name, bool visibility) : this()
    {
        Id = id;
        CollegeId = collegeId;
        Name = name;
        Visibility = visibility;
    }
}

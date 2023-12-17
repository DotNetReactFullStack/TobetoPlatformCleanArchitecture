using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class ForeignLanguage : Entity<int>
{
    public string Name { get; set; }
    public int Priority { get; set; }
    public bool Visibility { get; set; }

    public virtual ICollection<AccountForeignLanguageMetadata> AccountForeignLanguageMetadatas { get; set; }

    public ForeignLanguage()
    {
        
    }

    public ForeignLanguage(int id, string name, int priority, bool visibility) : this()
    {
        Id = id;
        Name = name;
        Priority = priority;
        Visibility = visibility;
    }
}

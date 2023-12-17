using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Certificate : Entity<int>
{
    public string Name { get; set; }
    public string Path { get; set; }
    public int Priority { get; set; }

    public virtual ICollection<AccountCertificate> AccountCertificates { get; set; }

    public Certificate()
    {
        
    }

    public Certificate(int id, string name, string path, int priority) : this()
    {
        Id = id;
        Name = name;
        Path = path;
        Priority = priority;
    }
}

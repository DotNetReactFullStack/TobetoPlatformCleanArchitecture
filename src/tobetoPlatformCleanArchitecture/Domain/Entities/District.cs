using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class District : Entity<int>
{
    public int CityId { get; set; }
    public string Name { get; set; }
    public int Priority { get; set; }
    public bool Visibility { get; set; }

    public virtual City? City { get; set; }
    public virtual ICollection<Address> Addresses { get; set; }

    public District()
    {
        
    }

    public District(int id, int cityId, string name, int priority, bool visibility) : this()
    {
        Id = id;
        CityId = cityId;
        Name = name;
        Priority = priority;
        Visibility = visibility;
    }
}

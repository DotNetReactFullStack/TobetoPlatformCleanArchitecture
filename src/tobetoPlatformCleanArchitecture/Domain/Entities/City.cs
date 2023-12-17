using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class City : Entity<int>
{
    public int CountryId { get; set; }
    public string Name { get; set; }
    public int Priority { get; set; }
    public bool Visibility { get; set; }

    public virtual Country? Country { get; set; }

    public virtual ICollection<Address> Addresses { get; set; }
    public virtual ICollection<District> Districts { get; set; }

    public City()
    {
        
    }

    public City(int id, int countryId, string name, int priority, bool visibility):this()
    {
        Id = id;
        CountryId = countryId;
        Name = name;
        Priority = priority;
        Visibility = visibility;
    }
}

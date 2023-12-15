using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Organization : Entity<int>
{
    public int OrganizationTypeId { get; set; }
    public int AddressId { get; set; }
    public bool Visibility { get; set; }
    public string Name { get; set; }
    public string ContactNumber { get; set; }


    public Organization()
    {
        
    }

    public Organization(int organizationTypeId, int addressId, bool visibility, string name, string contactNumber) : this()
    {
        OrganizationTypeId = organizationTypeId;
        AddressId = addressId;
        Visibility = visibility;
        Name = name;
        ContactNumber = contactNumber;
    }
}

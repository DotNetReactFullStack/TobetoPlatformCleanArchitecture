using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Domain.Entities;
public class Organization : Entity<int>
{
    public int OrganizationTypeId { get; set; }
    public int AddressId { get; set; }
    public bool Visibility { get; set; }
    public string Name { get; set; }
    public string ContactNumber { get; set; }

    public virtual OrganizationType? OrganizationType { get; set; }
    public virtual Address? Address { get; set; }

    public virtual ICollection<Survey> Surveys { get; set; }
    public virtual ICollection<Recourse> Recourses { get; set; }
    public virtual ICollection<Announcement> Announcements { get; set; }

    public Organization()
    {
        
    }

    public Organization(int id, int organizationTypeId, int addressId, bool visibility, string name, string contactNumber) : this()
    {
        Id = id;
        OrganizationTypeId = organizationTypeId;
        AddressId = addressId;
        Visibility = visibility;
        Name = name;
        ContactNumber = contactNumber;
    }
}

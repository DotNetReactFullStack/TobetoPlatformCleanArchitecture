using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Recourse : Entity<int>
{
    public int OrganizationId { get; set; }
    public int Priority { get; set; }
    public bool Visibility { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public bool IsActive { get; set; }
    public DateTime PublishedDate { get; set; }

    public virtual Organization Organization { get; set; }
    public virtual ICollection<AccountRecourse> AccountRecourses { get; set; }

    public Recourse()
    {
        
    }

    public Recourse(int id, int organizationId, int priority, bool visibility, string title, string content, DateTime publishedDate, bool isActive) : this()
    {
        Id = id;
        OrganizationId = organizationId;
        Priority = priority;
        Visibility = visibility;
        Title = title;
        Content = content;
        IsActive = isActive;
        PublishedDate = publishedDate;
    }
}

using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Announcement : Entity<int>
{
    public int AnnouncementTypeId { get; set; }
    public int OrganizationId { get; set; }
    public int Priority { get; set; }
    public bool Visibility { get; set; }
    public string Name { get; set; }
    public string Content { get; set; }
    public DateTime PublishedDate { get; set; }

    public virtual AnnouncementType? AnnouncementType { get; set; }
    public virtual Organization? Organization { get; set; }
    public virtual ICollection<AccountAnnouncement> AccountAnnouncements { get; set; }

    public Announcement()
    {
        
    }

    public Announcement(int id, int announcementTypeId, int organizationId, int priority, bool visibility, string name, string content, DateTime publishedDate):this()
    {
        Id = id;
        AnnouncementTypeId = announcementTypeId;
        OrganizationId = organizationId;
        Priority = priority;
        Visibility = visibility;
        Name = name;
        Content = content;
        PublishedDate = publishedDate;
    }
}

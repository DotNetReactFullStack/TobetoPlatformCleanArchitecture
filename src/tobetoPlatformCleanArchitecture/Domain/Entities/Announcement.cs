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
    public bool Visibility { get; set; }
    public string Name { get; set; }
    public string Content { get; set; }
    public DateTime PublishedDate { get; set; }


    public Announcement()
    {
        
    }

    public Announcement(int announcementTypeId, int organizationId, bool visibility, string name, string content, DateTime publishedDate) : this()
    {
        AnnouncementTypeId = announcementTypeId;
        OrganizationId = organizationId;
        Visibility = visibility;
        Name = name;
        Content = content;
        PublishedDate = publishedDate;
    }
}

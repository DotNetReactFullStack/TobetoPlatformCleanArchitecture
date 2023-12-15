using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Application : Entity<int>
{
    public int OrganizationId { get; set; }
    public bool Visibility { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime PublishedDate { get; set; }


    public Application()
    {
        
    }

    public Application(int organizationId, bool visibility, string title, string content, DateTime publishedDate) : this()
    {
        OrganizationId = organizationId;
        Visibility = visibility;
        Title = title;
        Content = content;
        PublishedDate = publishedDate;
    }
}

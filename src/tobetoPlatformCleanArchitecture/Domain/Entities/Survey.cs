using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Survey : Entity<int>
{
    public int SurveyTypeId { get; set; }
    public int OrganizationId { get; set; }
    public bool Visibility { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string ConnectionLink { get; set; }
    public DateTime PublishedDate { get; set; }

    public Survey()
    {
        
    }

    public Survey(int surveyTypeId, int organizationId, bool visibility, string title, string content, string connectionLink, DateTime publishedDate):this()
    {
        SurveyTypeId = surveyTypeId;
        OrganizationId = organizationId;
        Visibility = visibility;
        Title = title;
        Content = content;
        ConnectionLink = connectionLink;
        PublishedDate = publishedDate;
    }
}

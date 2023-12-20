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
    public int Priority { get; set; }
    public bool Visibility { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string ConnectionLink { get; set; }
    public bool IsActive { get; set; }
    public DateTime PublishedDate { get; set; }

    public virtual SurveyType? SurveyType { get; set; }
    public virtual Organization? Organization { get; set; }

    public Survey()
    {
        
    }

    public Survey(int id, int surveyTypeId, int organizationId, int priority, bool visibility, string title, string content, string connectionLink, bool isActive, DateTime publishedDate) : this()
    {
        Id = id;
        SurveyTypeId = surveyTypeId;
        OrganizationId = organizationId;
        Priority = priority;
        Visibility = visibility;
        Title = title;
        Content = content;
        ConnectionLink = connectionLink;
        IsActive = isActive;
        PublishedDate = publishedDate;
    }
}

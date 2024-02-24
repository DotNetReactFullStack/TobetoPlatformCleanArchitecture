using Core.Application.Dtos;
using System;
namespace Application.Features.AccountAnnouncements.Queries.GetListByAccountId
{
    public class GetListByAccountIdAccountAnnouncementListItemDto : IDto
    {
        public int Id { get; set; }
        public string AnnouncementTypeName { get; set; }
        public string OrganizationName { get; set; }
        public bool Read { get; set; }
        public int Priority { get; set; }
        public bool Visibility { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}


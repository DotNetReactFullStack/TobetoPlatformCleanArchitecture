using Core.Application.Dtos;
using System;
namespace Application.Features.AccountAnnouncements.Queries.GetListByAccountId
{
    public class GetListByAccountIdAccountAnnouncementListItemDto : IDto
    {
        public int Id { get; set; }
        public string AnnouncementTypeName { get; set; }
        public string OrganizationName { get; set; }
    }
}


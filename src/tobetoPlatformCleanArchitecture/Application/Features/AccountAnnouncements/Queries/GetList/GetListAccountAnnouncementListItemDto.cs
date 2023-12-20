using Core.Application.Dtos;

namespace Application.Features.AccountAnnouncements.Queries.GetList;

public class GetListAccountAnnouncementListItemDto : IDto
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public int AnnouncementId { get; set; }
    public bool Read { get; set; }
}
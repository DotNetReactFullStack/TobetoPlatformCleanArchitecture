using Core.Application.Responses;

namespace Application.Features.AccountAnnouncements.Queries.GetById;

public class GetByIdAccountAnnouncementResponse : IResponse
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public int AnnouncementId { get; set; }
    public bool Read { get; set; }
}
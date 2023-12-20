using Core.Application.Responses;

namespace Application.Features.AccountAnnouncements.Commands.Update;

public class UpdatedAccountAnnouncementResponse : IResponse
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public int AnnouncementId { get; set; }
    public bool Read { get; set; }
}
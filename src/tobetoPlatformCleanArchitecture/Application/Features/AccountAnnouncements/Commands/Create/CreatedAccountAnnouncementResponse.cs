using Core.Application.Responses;

namespace Application.Features.AccountAnnouncements.Commands.Create;

public class CreatedAccountAnnouncementResponse : IResponse
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public int AnnouncementId { get; set; }
    public bool Read { get; set; }
}
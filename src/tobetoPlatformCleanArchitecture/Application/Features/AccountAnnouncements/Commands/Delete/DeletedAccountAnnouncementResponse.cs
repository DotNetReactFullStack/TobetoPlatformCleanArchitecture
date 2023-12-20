using Core.Application.Responses;

namespace Application.Features.AccountAnnouncements.Commands.Delete;

public class DeletedAccountAnnouncementResponse : IResponse
{
    public int Id { get; set; }
}
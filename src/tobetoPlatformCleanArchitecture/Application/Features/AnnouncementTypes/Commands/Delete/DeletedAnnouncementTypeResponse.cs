using Core.Application.Responses;

namespace Application.Features.AnnouncementTypes.Commands.Delete;

public class DeletedAnnouncementTypeResponse : IResponse
{
    public int Id { get; set; }
}
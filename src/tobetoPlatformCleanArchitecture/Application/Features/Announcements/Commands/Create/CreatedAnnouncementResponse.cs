using Core.Application.Responses;

namespace Application.Features.Announcements.Commands.Create;

public class CreatedAnnouncementResponse : IResponse
{
    public int Id { get; set; }
    public int AnnouncementTypeId { get; set; }
    public int OrganizationId { get; set; }
    public int Priority { get; set; }
    public bool Visibility { get; set; }
    public string Name { get; set; }
    public string Content { get; set; }
    public DateTime PublishedDate { get; set; }
}
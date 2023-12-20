using Core.Application.Responses;

namespace Application.Features.Recourses.Commands.Create;

public class CreatedRecourseResponse : IResponse
{
    public int Id { get; set; }
    public int OrganizationId { get; set; }
    public int Priority { get; set; }
    public bool Visibility { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public bool IsActive { get; set; }
    public DateTime PublishedDate { get; set; }
}
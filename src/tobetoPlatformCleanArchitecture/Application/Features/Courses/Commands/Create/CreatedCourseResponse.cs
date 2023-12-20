using Core.Application.Responses;

namespace Application.Features.Courses.Commands.Create;

public class CreatedCourseResponse : IResponse
{
    public int Id { get; set; }
    public int CourseCategoryId { get; set; }
    public string Name { get; set; }
    public int TotalDuration { get; set; }
    public int Priority { get; set; }
    public bool IsActive { get; set; }
}
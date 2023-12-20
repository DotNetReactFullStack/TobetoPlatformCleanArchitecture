using Core.Application.Responses;

namespace Application.Features.Lessons.Queries.GetById;

public class GetByIdLessonResponse : IResponse
{
    public int Id { get; set; }
    public int CourseId { get; set; }
    public string Name { get; set; }
    public bool Visibility { get; set; }
    public string Language { get; set; }
    public string Content { get; set; }
    public int Duration { get; set; }
    public bool IsActive { get; set; }
}
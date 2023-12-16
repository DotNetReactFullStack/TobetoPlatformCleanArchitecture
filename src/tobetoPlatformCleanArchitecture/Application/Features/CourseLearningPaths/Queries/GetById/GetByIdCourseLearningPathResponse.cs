using Core.Application.Responses;

namespace Application.Features.CourseLearningPaths.Queries.GetById;

public class GetByIdCourseLearningPathResponse : IResponse
{
    public int Id { get; set; }
    public int CourseId { get; set; }
    public int PathId { get; set; }
    public bool Visibility { get; set; }
}
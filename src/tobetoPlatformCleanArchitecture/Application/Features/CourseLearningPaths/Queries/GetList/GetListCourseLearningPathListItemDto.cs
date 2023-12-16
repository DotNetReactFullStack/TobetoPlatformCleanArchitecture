using Core.Application.Dtos;

namespace Application.Features.CourseLearningPaths.Queries.GetList;

public class GetListCourseLearningPathListItemDto : IDto
{
    public int Id { get; set; }
    public int CourseId { get; set; }
    public int PathId { get; set; }
    public bool Visibility { get; set; }
}
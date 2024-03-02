using Core.Application.Dtos;

namespace Application.Features.CourseLearningPaths.Queries.GetList;

public class GetListCourseLearningPathListItemDto : IDto
{
    public int Id { get; set; }
    public int CourseId { get; set; }
    public int LearningPathId { get; set; }
    public int CourseCategoryId { get; set; }
    public string CourseName { get; set; }
    public int TotalDuration { get; set; }
    public int Priority { get; set; }
    public bool IsActive { get; set; }
    public bool Visibility { get; set; }
}
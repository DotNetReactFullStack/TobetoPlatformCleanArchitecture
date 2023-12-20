using Core.Application.Dtos;

namespace Application.Features.Courses.Queries.GetList;

public class GetListCourseListItemDto : IDto
{
    public int Id { get; set; }
    public int CourseCategoryId { get; set; }
    public string Name { get; set; }
    public int TotalDuration { get; set; }
    public int Priority { get; set; }
    public bool IsActive { get; set; }
}
using Core.Application.Dtos;

namespace Application.Features.AccountCourses.Queries.GetList;

public class GetListAccountCourseListItemDto : IDto
{
    public int Id { get; set; }
    public int CourseId { get; set; }
    public int AccountId { get; set; }
    public bool IsActive { get; set; }
}
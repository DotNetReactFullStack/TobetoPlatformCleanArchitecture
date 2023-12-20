using Core.Application.Responses;

namespace Application.Features.AccountCourses.Queries.GetById;

public class GetByIdAccountCourseResponse : IResponse
{
    public int Id { get; set; }
    public int CourseId { get; set; }
    public int AccountId { get; set; }
    public bool IsActive { get; set; }
}
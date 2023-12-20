using Core.Application.Responses;

namespace Application.Features.AccountCourses.Commands.Update;

public class UpdatedAccountCourseResponse : IResponse
{
    public int Id { get; set; }
    public int CourseId { get; set; }
    public int AccountId { get; set; }
    public bool IsActive { get; set; }
}
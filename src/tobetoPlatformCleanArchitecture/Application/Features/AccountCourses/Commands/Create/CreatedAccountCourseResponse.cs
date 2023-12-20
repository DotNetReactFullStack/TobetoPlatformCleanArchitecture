using Core.Application.Responses;

namespace Application.Features.AccountCourses.Commands.Create;

public class CreatedAccountCourseResponse : IResponse
{
    public int Id { get; set; }
    public int CourseId { get; set; }
    public int AccountId { get; set; }
    public bool IsActive { get; set; }
}
using Core.Application.Responses;

namespace Application.Features.AccountCourses.Commands.Delete;

public class DeletedAccountCourseResponse : IResponse
{
    public int Id { get; set; }
}
using Core.Application.Responses;

namespace Application.Features.Courses.Commands.Delete;

public class DeletedCourseResponse : IResponse
{
    public int Id { get; set; }
}
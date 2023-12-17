using Core.Application.Responses;

namespace Application.Features.Recourses.Commands.Delete;

public class DeletedRecourseResponse : IResponse
{
    public int Id { get; set; }
}
using Core.Application.Responses;

namespace Application.Features.AccountRecourses.Commands.Delete;

public class DeletedAccountRecourseResponse : IResponse
{
    public int Id { get; set; }
}
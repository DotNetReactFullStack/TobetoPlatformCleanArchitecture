using Core.Application.Responses;

namespace Application.Features.AccountClassrooms.Commands.Delete;

public class DeletedAccountClassroomResponse : IResponse
{
    public int Id { get; set; }
}
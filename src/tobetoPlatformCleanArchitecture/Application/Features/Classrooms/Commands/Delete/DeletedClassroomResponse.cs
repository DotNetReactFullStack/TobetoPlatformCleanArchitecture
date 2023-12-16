using Core.Application.Responses;

namespace Application.Features.Classrooms.Commands.Delete;

public class DeletedClassroomResponse : IResponse
{
    public int Id { get; set; }
}
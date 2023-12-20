using Core.Application.Responses;

namespace Application.Features.Classrooms.Commands.Update;

public class UpdatedClassroomResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public byte MaximumCapacity { get; set; }
    public bool IsActive { get; set; }
}
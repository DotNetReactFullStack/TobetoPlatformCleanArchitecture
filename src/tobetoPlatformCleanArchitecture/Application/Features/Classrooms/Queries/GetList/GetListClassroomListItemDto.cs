using Core.Application.Dtos;

namespace Application.Features.Classrooms.Queries.GetList;

public class GetListClassroomListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public byte MaximumCapacity { get; set; }
    public bool IsActive { get; set; }
}
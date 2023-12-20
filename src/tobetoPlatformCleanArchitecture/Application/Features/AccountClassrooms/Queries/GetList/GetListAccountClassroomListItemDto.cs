using Core.Application.Dtos;

namespace Application.Features.AccountClassrooms.Queries.GetList;

public class GetListAccountClassroomListItemDto : IDto
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public int ClassroomId { get; set; }
    public bool IsActive { get; set; }
}
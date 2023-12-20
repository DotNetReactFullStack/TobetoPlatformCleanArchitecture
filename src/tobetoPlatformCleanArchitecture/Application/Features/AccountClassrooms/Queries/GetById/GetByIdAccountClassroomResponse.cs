using Core.Application.Responses;

namespace Application.Features.AccountClassrooms.Queries.GetById;

public class GetByIdAccountClassroomResponse : IResponse
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public int ClassroomId { get; set; }
    public bool IsActive { get; set; }
}
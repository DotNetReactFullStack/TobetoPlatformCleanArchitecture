using Core.Application.Responses;

namespace Application.Features.Colleges.Commands.Delete;

public class DeletedCollegeResponse : IResponse
{
    public int Id { get; set; }
}
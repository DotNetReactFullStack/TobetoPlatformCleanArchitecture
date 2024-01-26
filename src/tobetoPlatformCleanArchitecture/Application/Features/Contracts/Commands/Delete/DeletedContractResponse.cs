using Core.Application.Responses;

namespace Application.Features.Contracts.Commands.Delete;

public class DeletedContractResponse : IResponse
{
    public int Id { get; set; }
}
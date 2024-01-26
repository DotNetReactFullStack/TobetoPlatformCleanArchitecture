using Core.Application.Responses;

namespace Application.Features.AccountContracts.Commands.Delete;

public class DeletedAccountContractResponse : IResponse
{
    public int Id { get; set; }
}
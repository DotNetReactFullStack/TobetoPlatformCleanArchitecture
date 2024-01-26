using Core.Application.Responses;

namespace Application.Features.ContractTypes.Commands.Delete;

public class DeletedContractTypeResponse : IResponse
{
    public int Id { get; set; }
}
using Core.Application.Responses;

namespace Application.Features.AccountContracts.Commands.Update;

public class UpdatedAccountContractResponse : IResponse
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public int ContractId { get; set; }
    public bool IsAccept { get; set; }
}
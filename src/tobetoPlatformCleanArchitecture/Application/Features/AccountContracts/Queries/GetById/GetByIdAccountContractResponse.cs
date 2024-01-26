using Core.Application.Responses;

namespace Application.Features.AccountContracts.Queries.GetById;

public class GetByIdAccountContractResponse : IResponse
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public int ContractId { get; set; }
    public bool IsAccept { get; set; }
}
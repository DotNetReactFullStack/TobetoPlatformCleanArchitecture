using Core.Application.Dtos;

namespace Application.Features.AccountContracts.Queries.GetList;

public class GetListAccountContractListItemDto : IDto
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public int ContractId { get; set; }
    public bool IsAccept { get; set; }
}
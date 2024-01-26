using Core.Application.Dtos;

namespace Application.Features.Contracts.Queries.GetList;

public class GetListContractListItemDto : IDto
{
    public int Id { get; set; }
    public int ContractTypeId { get; set; }
    public string Name { get; set; }
    public string Path { get; set; }
    public bool IsActive { get; set; }
}
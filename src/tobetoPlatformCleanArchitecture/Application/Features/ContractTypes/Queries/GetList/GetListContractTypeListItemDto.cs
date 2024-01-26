using Core.Application.Dtos;

namespace Application.Features.ContractTypes.Queries.GetList;

public class GetListContractTypeListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
}
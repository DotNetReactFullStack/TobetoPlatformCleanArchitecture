using Core.Application.Dtos;

namespace Application.Features.AccountCapabilities.Queries.GetList;

public class GetListAccountCapabilityListItemDto : IDto
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public int CapabilityId { get; set; }
    public int Priority { get; set; }
}
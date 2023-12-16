using Core.Application.Dtos;

namespace Application.Features.OrganizationTypes.Queries.GetList;

public class GetListOrganizationTypeListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Priority { get; set; }
    public bool Visibility { get; set; }
}
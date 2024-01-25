using Core.Application.Dtos;

namespace Application.Features.ImageExtensions.Queries.GetList;

public class GetListImageExtensionListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
}
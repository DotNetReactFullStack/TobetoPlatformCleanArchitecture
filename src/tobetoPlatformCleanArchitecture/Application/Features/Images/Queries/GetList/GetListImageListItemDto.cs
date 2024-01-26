using Core.Application.Dtos;

namespace Application.Features.Images.Queries.GetList;

public class GetListImageListItemDto : IDto
{
    public int Id { get; set; }
    public int ImageExtensionId { get; set; }
    public string Name { get; set; }
    public string Url { get; set; }
    public bool IsActive { get; set; }
}
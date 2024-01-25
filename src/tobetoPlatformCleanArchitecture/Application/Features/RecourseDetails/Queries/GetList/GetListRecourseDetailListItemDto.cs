using Core.Application.Dtos;

namespace Application.Features.RecourseDetails.Queries.GetList;

public class GetListRecourseDetailListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Priority { get; set; }
    public bool Visibility { get; set; }
}
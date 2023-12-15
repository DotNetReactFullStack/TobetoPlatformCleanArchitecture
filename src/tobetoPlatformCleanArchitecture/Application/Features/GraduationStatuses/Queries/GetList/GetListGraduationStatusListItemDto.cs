using Core.Application.Dtos;

namespace Application.Features.GraduationStatuses.Queries.GetList;

public class GetListGraduationStatusListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Priority { get; set; }
    public bool Visibility { get; set; }
}
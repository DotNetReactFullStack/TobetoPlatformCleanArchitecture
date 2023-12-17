using Core.Application.Dtos;

namespace Application.Features.RecourseSteps.Queries.GetList;

public class GetListRecourseStepListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Priority { get; set; }
    public bool Visibility { get; set; }
}
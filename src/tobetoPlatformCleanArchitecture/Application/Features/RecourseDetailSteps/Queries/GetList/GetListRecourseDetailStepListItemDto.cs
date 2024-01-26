using Core.Application.Dtos;

namespace Application.Features.RecourseDetailSteps.Queries.GetList;

public class GetListRecourseDetailStepListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Priority { get; set; }
    public bool Visibility { get; set; }
}
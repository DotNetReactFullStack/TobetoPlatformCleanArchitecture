using Core.Application.Responses;

namespace Application.Features.RecourseSteps.Queries.GetById;

public class GetByIdRecourseStepResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Priority { get; set; }
    public bool Visibility { get; set; }
}
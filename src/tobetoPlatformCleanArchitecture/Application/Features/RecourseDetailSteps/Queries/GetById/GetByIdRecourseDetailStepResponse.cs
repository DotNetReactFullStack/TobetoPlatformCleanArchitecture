using Core.Application.Responses;

namespace Application.Features.RecourseDetailSteps.Queries.GetById;

public class GetByIdRecourseDetailStepResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Priority { get; set; }
    public bool Visibility { get; set; }
}
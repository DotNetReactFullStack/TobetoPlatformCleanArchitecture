using Core.Application.Responses;

namespace Application.Features.RecourseSteps.Commands.Update;

public class UpdatedRecourseStepResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Priority { get; set; }
    public bool Visibility { get; set; }
}
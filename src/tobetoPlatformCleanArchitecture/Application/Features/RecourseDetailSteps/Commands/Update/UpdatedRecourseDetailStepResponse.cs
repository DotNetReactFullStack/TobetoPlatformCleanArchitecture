using Core.Application.Responses;

namespace Application.Features.RecourseDetailSteps.Commands.Update;

public class UpdatedRecourseDetailStepResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Priority { get; set; }
    public bool Visibility { get; set; }
}
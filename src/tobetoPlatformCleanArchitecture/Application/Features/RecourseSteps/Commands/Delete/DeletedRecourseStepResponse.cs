using Core.Application.Responses;

namespace Application.Features.RecourseSteps.Commands.Delete;

public class DeletedRecourseStepResponse : IResponse
{
    public int Id { get; set; }
}
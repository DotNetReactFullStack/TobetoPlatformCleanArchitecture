using Core.Application.Responses;

namespace Application.Features.RecourseDetailSteps.Commands.Delete;

public class DeletedRecourseDetailStepResponse : IResponse
{
    public int Id { get; set; }
}
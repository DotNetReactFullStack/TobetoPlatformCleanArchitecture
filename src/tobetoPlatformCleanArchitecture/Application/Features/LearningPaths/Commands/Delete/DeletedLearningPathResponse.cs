using Core.Application.Responses;

namespace Application.Features.LearningPaths.Commands.Delete;

public class DeletedLearningPathResponse : IResponse
{
    public int Id { get; set; }
}
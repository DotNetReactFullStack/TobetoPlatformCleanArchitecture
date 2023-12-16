using Core.Application.Responses;

namespace Application.Features.AccountLearningPaths.Commands.Delete;

public class DeletedAccountLearningPathResponse : IResponse
{
    public int Id { get; set; }
}
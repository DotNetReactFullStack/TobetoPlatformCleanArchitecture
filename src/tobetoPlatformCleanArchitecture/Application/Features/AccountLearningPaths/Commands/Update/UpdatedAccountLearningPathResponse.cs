using Core.Application.Responses;

namespace Application.Features.AccountLearningPaths.Commands.Update;

public class UpdatedAccountLearningPathResponse : IResponse
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public int PathId { get; set; }
    public int TotalNumberOfPoints { get; set; }
    public byte PercentCompleted { get; set; }
}
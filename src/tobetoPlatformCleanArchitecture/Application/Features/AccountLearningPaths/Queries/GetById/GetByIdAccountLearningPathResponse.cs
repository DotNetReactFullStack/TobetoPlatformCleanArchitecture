using Core.Application.Responses;

namespace Application.Features.AccountLearningPaths.Queries.GetById;

public class GetByIdAccountLearningPathResponse : IResponse
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public int PathId { get; set; }
    public int TotalNumberOfPoints { get; set; }
    public byte PercentCompleted { get; set; }
}
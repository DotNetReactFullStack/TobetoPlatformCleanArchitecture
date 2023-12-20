using Core.Application.Responses;

namespace Application.Features.AccountLearningPaths.Queries.GetById;

public class GetByIdAccountLearningPathResponse : IResponse
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public int LearningPathId { get; set; }
    public int TotalNumberOfPoints { get; set; }
    public byte PercentComplete { get; set; }
    public bool IsContinue { get; set; }
    public bool IsComplete { get; set; }
    public bool IsLiked { get; set; }
    public bool IsSaved { get; set; }
    public bool IsActive { get; set; }
}
using Core.Application.Responses;

namespace Application.Features.AccountLearningPaths.Queries.GetListByLearningPathId;
public class GetByAccountIdAndLearningPathIdAccountLearningPathResponse : IResponse
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public int LearningPathId { get; set; }
    public int LearningPathCategoryId { get; set; }
    public string LearningPathName { get; set; }
    public bool Visibility { get; set; }
    public DateTime StartingTime { get; set; }
    public DateTime EndingTime { get; set; }
    public int NumberOfLikes { get; set; }
    public int TotalDuration { get; set; }
    public string ImageUrl { get; set; }
    public int TotalNumberOfPoints { get; set; }
    public byte PercentComplete { get; set; }
    public bool IsContinue { get; set; }
    public bool IsComplete { get; set; }
    public bool IsLiked { get; set; }
    public bool IsSaved { get; set; }
    public bool IsActive { get; set; }
}

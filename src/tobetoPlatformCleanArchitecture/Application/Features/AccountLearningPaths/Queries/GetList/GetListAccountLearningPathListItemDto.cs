using Core.Application.Dtos;

namespace Application.Features.AccountLearningPaths.Queries.GetList;

public class GetListAccountLearningPathListItemDto : IDto
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public int PathId { get; set; }
    public int TotalNumberOfPoints { get; set; }
    public byte PercentCompleted { get; set; }
}
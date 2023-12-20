using Core.Application.Dtos;

namespace Application.Features.LearningPaths.Queries.GetList;

public class GetListLearningPathListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool Visibility { get; set; }
    public DateTime StartingTime { get; set; }
    public DateTime EndingTime { get; set; }
    public int NumberOfLikes { get; set; }
    public int TotalDuration { get; set; }
}
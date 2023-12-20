using Core.Application.Dtos;

namespace Application.Features.AccountLessons.Queries.GetList;

public class GetListAccountLessonListItemDto : IDto
{
    public int Id { get; set; }
    public int LessonId { get; set; }
    public int AccountId { get; set; }
    public int Points { get; set; }
    public bool IsComplete { get; set; }
}
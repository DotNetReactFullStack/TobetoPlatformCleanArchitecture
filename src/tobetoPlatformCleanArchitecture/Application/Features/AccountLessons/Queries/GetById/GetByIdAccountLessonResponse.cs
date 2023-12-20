using Core.Application.Responses;

namespace Application.Features.AccountLessons.Queries.GetById;

public class GetByIdAccountLessonResponse : IResponse
{
    public int Id { get; set; }
    public int LessonId { get; set; }
    public int AccountId { get; set; }
    public int Points { get; set; }
    public bool IsComplete { get; set; }
}
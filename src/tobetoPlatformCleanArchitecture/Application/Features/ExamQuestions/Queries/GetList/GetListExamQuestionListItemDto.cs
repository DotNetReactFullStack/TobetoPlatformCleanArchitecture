using Core.Application.Dtos;

namespace Application.Features.ExamQuestions.Queries.GetList;

public class GetListExamQuestionListItemDto : IDto
{
    public int Id { get; set; }
    public int ExamId { get; set; }
    public int QuestionId { get; set; }
}
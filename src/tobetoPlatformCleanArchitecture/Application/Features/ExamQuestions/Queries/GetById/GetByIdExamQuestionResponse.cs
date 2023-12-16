using Core.Application.Responses;

namespace Application.Features.ExamQuestions.Queries.GetById;

public class GetByIdExamQuestionResponse : IResponse
{
    public int Id { get; set; }
    public int ExamId { get; set; }
    public int QuestionId { get; set; }
}
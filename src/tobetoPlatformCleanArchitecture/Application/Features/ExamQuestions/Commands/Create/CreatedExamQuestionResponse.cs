using Core.Application.Responses;

namespace Application.Features.ExamQuestions.Commands.Create;

public class CreatedExamQuestionResponse : IResponse
{
    public int Id { get; set; }
    public int ExamId { get; set; }
    public int QuestionId { get; set; }
}
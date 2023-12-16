using Core.Application.Responses;

namespace Application.Features.ExamQuestions.Commands.Update;

public class UpdatedExamQuestionResponse : IResponse
{
    public int Id { get; set; }
    public int ExamId { get; set; }
    public int QuestionId { get; set; }
}
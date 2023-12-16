using Core.Application.Responses;

namespace Application.Features.ExamQuestions.Commands.Delete;

public class DeletedExamQuestionResponse : IResponse
{
    public int Id { get; set; }
}
using Core.Application.Responses;

namespace Application.Features.AccountExamResults.Commands.Update;

public class UpdatedAccountExamResultResponse : IResponse
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public int ExamId { get; set; }
    public bool Visibility { get; set; }
    public int NumberOfRightAnswers { get; set; }
    public int NumberOfWrongAnswers { get; set; }
    public int NumberOfNullAnswers { get; set; }
    public int Points { get; set; }
}
using Core.Application.Responses;

namespace Application.Features.Questions.Commands.Update;

public class UpdatedQuestionResponse : IResponse
{
    public int Id { get; set; }
    public int QuestionCategoryId { get; set; }
    public string QuestionDetail { get; set; }
    public bool IsActive { get; set; }
}
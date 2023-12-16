using Core.Application.Responses;

namespace Application.Features.Answers.Commands.Update;

public class UpdatedAnswerResponse : IResponse
{
    public int Id { get; set; }
    public int QuestionId { get; set; }
    public string AnswerDetail { get; set; }
    public bool RightAnswerBool { get; set; }
}
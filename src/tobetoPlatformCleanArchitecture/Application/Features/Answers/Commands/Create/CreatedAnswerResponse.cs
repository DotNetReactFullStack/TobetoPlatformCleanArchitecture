using Core.Application.Responses;

namespace Application.Features.Answers.Commands.Create;

public class CreatedAnswerResponse : IResponse
{
    public int Id { get; set; }
    public int QuestionId { get; set; }
    public string AnswerDetail { get; set; }
    public bool RightAnswerBool { get; set; }
}
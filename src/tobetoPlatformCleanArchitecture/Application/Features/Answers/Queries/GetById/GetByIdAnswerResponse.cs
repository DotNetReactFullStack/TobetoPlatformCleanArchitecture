using Core.Application.Responses;

namespace Application.Features.Answers.Queries.GetById;

public class GetByIdAnswerResponse : IResponse
{
    public int Id { get; set; }
    public int QuestionId { get; set; }
    public string AnswerDetail { get; set; }
    public bool RightAnswerBool { get; set; }
}
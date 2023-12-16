using Core.Application.Dtos;

namespace Application.Features.Answers.Queries.GetList;

public class GetListAnswerListItemDto : IDto
{
    public int Id { get; set; }
    public int QuestionId { get; set; }
    public string AnswerDetail { get; set; }
    public bool RightAnswerBool { get; set; }
}
using Core.Application.Responses;

namespace Application.Features.Questions.Queries.GetById;

public class GetByIdQuestionResponse : IResponse
{
    public int Id { get; set; }
    public int QuestionCategoryId { get; set; }
    public string QuestionDetail { get; set; }
    public bool IsActive { get; set; }
}
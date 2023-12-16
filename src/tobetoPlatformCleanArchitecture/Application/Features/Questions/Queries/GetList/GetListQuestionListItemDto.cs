using Core.Application.Dtos;

namespace Application.Features.Questions.Queries.GetList;

public class GetListQuestionListItemDto : IDto
{
    public int Id { get; set; }
    public int QuestionCategoryId { get; set; }
    public string QuestionDetail { get; set; }
    public bool IsActive { get; set; }
}
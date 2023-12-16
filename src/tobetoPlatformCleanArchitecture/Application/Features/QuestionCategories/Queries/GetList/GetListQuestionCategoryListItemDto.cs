using Core.Application.Dtos;

namespace Application.Features.QuestionCategories.Queries.GetList;

public class GetListQuestionCategoryListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Priority { get; set; }
}
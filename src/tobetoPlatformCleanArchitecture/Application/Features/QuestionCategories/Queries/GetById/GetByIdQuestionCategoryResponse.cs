using Core.Application.Responses;

namespace Application.Features.QuestionCategories.Queries.GetById;

public class GetByIdQuestionCategoryResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Priority { get; set; }
}
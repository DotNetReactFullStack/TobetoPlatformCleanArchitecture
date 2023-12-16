using Core.Application.Responses;

namespace Application.Features.QuestionCategories.Commands.Update;

public class UpdatedQuestionCategoryResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Priority { get; set; }
}
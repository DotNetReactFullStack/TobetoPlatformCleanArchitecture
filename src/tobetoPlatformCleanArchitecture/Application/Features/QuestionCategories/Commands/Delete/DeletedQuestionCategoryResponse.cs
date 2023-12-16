using Core.Application.Responses;

namespace Application.Features.QuestionCategories.Commands.Delete;

public class DeletedQuestionCategoryResponse : IResponse
{
    public int Id { get; set; }
}
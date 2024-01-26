using Core.Application.Responses;

namespace Application.Features.LearningPathCategories.Commands.Delete;

public class DeletedLearningPathCategoryResponse : IResponse
{
    public int Id { get; set; }
}
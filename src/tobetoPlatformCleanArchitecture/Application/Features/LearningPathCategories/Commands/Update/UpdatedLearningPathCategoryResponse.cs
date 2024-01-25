using Core.Application.Responses;

namespace Application.Features.LearningPathCategories.Commands.Update;

public class UpdatedLearningPathCategoryResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
}
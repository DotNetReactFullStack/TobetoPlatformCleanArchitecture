using Core.Application.Responses;

namespace Application.Features.LearningPathCategories.Commands.Create;

public class CreatedLearningPathCategoryResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
}
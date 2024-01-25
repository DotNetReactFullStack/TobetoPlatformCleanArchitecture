using Core.Application.Responses;

namespace Application.Features.LearningPathCategories.Queries.GetById;

public class GetByIdLearningPathCategoryResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
}
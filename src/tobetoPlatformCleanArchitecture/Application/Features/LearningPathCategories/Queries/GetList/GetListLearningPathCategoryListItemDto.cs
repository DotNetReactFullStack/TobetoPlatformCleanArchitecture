using Core.Application.Dtos;

namespace Application.Features.LearningPathCategories.Queries.GetList;

public class GetListLearningPathCategoryListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
}
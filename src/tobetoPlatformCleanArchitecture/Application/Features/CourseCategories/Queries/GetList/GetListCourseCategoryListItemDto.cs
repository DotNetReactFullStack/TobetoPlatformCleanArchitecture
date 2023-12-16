using Core.Application.Dtos;

namespace Application.Features.CourseCategories.Queries.GetList;

public class GetListCourseCategoryListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Priority { get; set; }
    public bool Visibility { get; set; }
}
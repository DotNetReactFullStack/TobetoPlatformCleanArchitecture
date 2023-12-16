using Core.Application.Responses;

namespace Application.Features.CourseCategories.Queries.GetById;

public class GetByIdCourseCategoryResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Priority { get; set; }
    public bool Visibility { get; set; }
}
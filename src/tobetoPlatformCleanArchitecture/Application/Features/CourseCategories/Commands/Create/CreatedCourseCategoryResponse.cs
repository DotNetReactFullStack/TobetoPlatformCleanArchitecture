using Core.Application.Responses;

namespace Application.Features.CourseCategories.Commands.Create;

public class CreatedCourseCategoryResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Priority { get; set; }
    public bool Visibility { get; set; }
}
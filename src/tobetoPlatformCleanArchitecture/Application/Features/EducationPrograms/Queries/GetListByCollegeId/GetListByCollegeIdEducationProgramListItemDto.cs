using Core.Application.Dtos;

namespace Application.Features.EducationPrograms.Queries.GetListByCollegeId;
public class GetListByCollegeIdEducationProgramListItemDto : IDto
{
    public int Id { get; set; }
    public int CollegeId { get; set; }
    public string Name { get; set; }
    public bool Visibility { get; set; }
}


using Core.Application.Dtos;

namespace Application.Features.Colleges.Queries.GetList;

public class GetListCollegeListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool Visibility { get; set; }
}
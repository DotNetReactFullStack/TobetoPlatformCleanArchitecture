using Core.Application.Dtos;

namespace Application.Features.Experiences.Queries.GetList;

public class GetListExperienceListItemDto : IDto
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public int CityId { get; set; }
    public string CompanyName { get; set; }
    public string JobTitle { get; set; }
    public string Industry { get; set; }
    public DateTime StartingDate { get; set; }
    public DateTime? EndingDate { get; set; }
    public bool IsCurrentlyWorking { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; }
}
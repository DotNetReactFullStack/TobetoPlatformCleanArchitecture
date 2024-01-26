using Core.Application.Responses;

namespace Application.Features.Experiences.Commands.Create;

public class CreatedExperienceResponse : IResponse
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
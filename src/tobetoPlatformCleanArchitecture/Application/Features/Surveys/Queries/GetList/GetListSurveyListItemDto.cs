using Core.Application.Dtos;

namespace Application.Features.Surveys.Queries.GetList;

public class GetListSurveyListItemDto : IDto
{
    public int Id { get; set; }
    public int SurveyTypeId { get; set; }
    public int OrganizationId { get; set; }
    public int Priority { get; set; }
    public bool Visibility { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string ConnectionLink { get; set; }
    public bool IsActive { get; set; }
    public DateTime PublishedDate { get; set; }
}
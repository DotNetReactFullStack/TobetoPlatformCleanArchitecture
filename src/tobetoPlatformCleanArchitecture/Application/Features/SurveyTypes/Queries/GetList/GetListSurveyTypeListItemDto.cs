using Core.Application.Dtos;

namespace Application.Features.SurveyTypes.Queries.GetList;

public class GetListSurveyTypeListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Priority { get; set; }
    public bool Visibility { get; set; }
}
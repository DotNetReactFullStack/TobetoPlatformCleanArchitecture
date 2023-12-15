using Core.Application.Dtos;

namespace Application.Features.ForeignLanguages.Queries.GetList;

public class GetListForeignLanguageListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Priority { get; set; }
    public bool Visibility { get; set; }
}
using Core.Application.Dtos;

namespace Application.Features.AccountForeignLanguageMetadatas.Queries.GetList;

public class GetListAccountForeignLanguageMetadataListItemDto : IDto
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public int ForeignLanguageId { get; set; }
    public int ForeignLanguageLevelId { get; set; }
    public int Priority { get; set; }
}
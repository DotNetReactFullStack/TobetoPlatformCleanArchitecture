using Core.Application.Responses;

namespace Application.Features.AccountForeignLanguageMetadatas.Queries.GetById;

public class GetByIdAccountForeignLanguageMetadataResponse : IResponse
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public int ForeignLanguageId { get; set; }
    public int ForeignLanguageLevelId { get; set; }
    public int Priority { get; set; }
}
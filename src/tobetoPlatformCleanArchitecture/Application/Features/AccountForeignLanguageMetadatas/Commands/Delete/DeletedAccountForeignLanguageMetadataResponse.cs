using Core.Application.Responses;

namespace Application.Features.AccountForeignLanguageMetadatas.Commands.Delete;

public class DeletedAccountForeignLanguageMetadataResponse : IResponse
{
    public int Id { get; set; }
}
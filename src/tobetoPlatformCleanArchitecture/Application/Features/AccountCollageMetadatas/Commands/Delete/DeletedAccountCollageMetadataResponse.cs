using Core.Application.Responses;

namespace Application.Features.AccountCollageMetadatas.Commands.Delete;

public class DeletedAccountCollageMetadataResponse : IResponse
{
    public int Id { get; set; }
}
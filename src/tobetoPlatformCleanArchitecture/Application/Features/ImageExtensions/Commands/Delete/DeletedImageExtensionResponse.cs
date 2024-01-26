using Core.Application.Responses;

namespace Application.Features.ImageExtensions.Commands.Delete;

public class DeletedImageExtensionResponse : IResponse
{
    public int Id { get; set; }
}
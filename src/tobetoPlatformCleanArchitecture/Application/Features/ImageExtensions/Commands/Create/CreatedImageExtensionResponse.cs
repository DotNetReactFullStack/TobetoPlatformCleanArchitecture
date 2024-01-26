using Core.Application.Responses;

namespace Application.Features.ImageExtensions.Commands.Create;

public class CreatedImageExtensionResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
}
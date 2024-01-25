using Core.Application.Responses;

namespace Application.Features.ImageExtensions.Commands.Update;

public class UpdatedImageExtensionResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
}
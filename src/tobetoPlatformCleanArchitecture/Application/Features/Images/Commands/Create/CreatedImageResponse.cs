using Core.Application.Responses;

namespace Application.Features.Images.Commands.Create;

public class CreatedImageResponse : IResponse
{
    public int Id { get; set; }
    public int ImageExtensionId { get; set; }
    public string Name { get; set; }
    public string Url { get; set; }
    public bool IsActive { get; set; }
}
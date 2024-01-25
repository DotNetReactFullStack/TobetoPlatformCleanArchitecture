using Core.Application.Responses;

namespace Application.Features.Images.Commands.Update;

public class UpdatedImageResponse : IResponse
{
    public int Id { get; set; }
    public int ImageExtensionId { get; set; }
    public string Name { get; set; }
    public string Url { get; set; }
    public bool IsActive { get; set; }
}
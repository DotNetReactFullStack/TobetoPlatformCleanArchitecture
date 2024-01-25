using Core.Application.Responses;

namespace Application.Features.Images.Queries.GetById;

public class GetByIdImageResponse : IResponse
{
    public int Id { get; set; }
    public int ImageExtensionId { get; set; }
    public string Name { get; set; }
    public string Url { get; set; }
    public bool IsActive { get; set; }
}
using Core.Application.Responses;

namespace Application.Features.ImageExtensions.Queries.GetById;

public class GetByIdImageExtensionResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
}
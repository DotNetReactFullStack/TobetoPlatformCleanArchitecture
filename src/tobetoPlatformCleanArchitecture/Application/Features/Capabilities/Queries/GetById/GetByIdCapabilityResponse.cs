using Core.Application.Responses;

namespace Application.Features.Capabilities.Queries.GetById;

public class GetByIdCapabilityResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Priority { get; set; }
    public bool Visibility { get; set; }
}
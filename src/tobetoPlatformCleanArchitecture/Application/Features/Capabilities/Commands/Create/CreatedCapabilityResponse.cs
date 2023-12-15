using Core.Application.Responses;

namespace Application.Features.Capabilities.Commands.Create;

public class CreatedCapabilityResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Priority { get; set; }
    public bool Visibility { get; set; }
}
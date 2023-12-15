using Core.Application.Responses;

namespace Application.Features.Capabilities.Commands.Delete;

public class DeletedCapabilityResponse : IResponse
{
    public int Id { get; set; }
}
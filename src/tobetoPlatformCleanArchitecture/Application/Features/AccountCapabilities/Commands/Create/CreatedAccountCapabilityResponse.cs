using Core.Application.Responses;

namespace Application.Features.AccountCapabilities.Commands.Create;

public class CreatedAccountCapabilityResponse : IResponse
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public int CapabilityId { get; set; }
    public int Priority { get; set; }
}
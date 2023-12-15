using Core.Application.Responses;

namespace Application.Features.AccountCapabilities.Commands.Delete;

public class DeletedAccountCapabilityResponse : IResponse
{
    public int Id { get; set; }
}
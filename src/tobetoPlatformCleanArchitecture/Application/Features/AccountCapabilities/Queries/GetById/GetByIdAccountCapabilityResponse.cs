using Core.Application.Responses;

namespace Application.Features.AccountCapabilities.Queries.GetById;

public class GetByIdAccountCapabilityResponse : IResponse
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public int CapabilityId { get; set; }
    public int Priority { get; set; }
}
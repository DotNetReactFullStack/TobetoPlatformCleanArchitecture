using Core.Application.Responses;

namespace Application.Features.Organizations.Queries.GetById;

public class GetByIdOrganizationResponse : IResponse
{
    public int Id { get; set; }
    public int OrganizationTypeId { get; set; }
    public int AddressId { get; set; }
    public bool Visibility { get; set; }
    public string Name { get; set; }
    public string ContactNumber { get; set; }
}
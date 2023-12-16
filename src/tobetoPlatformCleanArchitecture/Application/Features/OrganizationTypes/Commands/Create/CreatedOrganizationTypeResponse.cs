using Core.Application.Responses;

namespace Application.Features.OrganizationTypes.Commands.Create;

public class CreatedOrganizationTypeResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Priority { get; set; }
    public bool Visibility { get; set; }
}
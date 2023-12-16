using Core.Application.Responses;

namespace Application.Features.OrganizationTypes.Commands.Delete;

public class DeletedOrganizationTypeResponse : IResponse
{
    public int Id { get; set; }
}
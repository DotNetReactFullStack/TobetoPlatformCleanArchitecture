using Core.Application.Responses;

namespace Application.Features.Organizations.Commands.Delete;

public class DeletedOrganizationResponse : IResponse
{
    public int Id { get; set; }
}
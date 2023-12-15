using Core.Application.Responses;

namespace Application.Features.Accounts.Commands.Delete;

public class DeletedAccountResponse : IResponse
{
    public Guid Id { get; set; }
}
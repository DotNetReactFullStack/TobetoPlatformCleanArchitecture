using Core.Application.Responses;

namespace Application.Features.AccountCertificates.Commands.Delete;

public class DeletedAccountCertificateResponse : IResponse
{
    public int Id { get; set; }
}
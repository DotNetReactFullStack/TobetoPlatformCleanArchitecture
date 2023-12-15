using Core.Application.Responses;

namespace Application.Features.AccountCertificates.Commands.Create;

public class CreatedAccountCertificateResponse : IResponse
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public int CertificateId { get; set; }
    public int Priority { get; set; }
}
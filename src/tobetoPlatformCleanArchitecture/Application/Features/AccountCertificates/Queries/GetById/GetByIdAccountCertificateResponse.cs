using Core.Application.Responses;

namespace Application.Features.AccountCertificates.Queries.GetById;

public class GetByIdAccountCertificateResponse : IResponse
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public int CertificateId { get; set; }
    public int Priority { get; set; }
}
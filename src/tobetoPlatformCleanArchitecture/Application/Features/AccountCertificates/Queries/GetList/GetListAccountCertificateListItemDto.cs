using Core.Application.Dtos;

namespace Application.Features.AccountCertificates.Queries.GetList;

public class GetListAccountCertificateListItemDto : IDto
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public int CertificateId { get; set; }
    public int Priority { get; set; }
}
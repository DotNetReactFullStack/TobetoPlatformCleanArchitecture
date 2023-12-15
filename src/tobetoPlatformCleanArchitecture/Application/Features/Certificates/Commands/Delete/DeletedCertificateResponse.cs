using Core.Application.Responses;

namespace Application.Features.Certificates.Commands.Delete;

public class DeletedCertificateResponse : IResponse
{
    public int Id { get; set; }
}
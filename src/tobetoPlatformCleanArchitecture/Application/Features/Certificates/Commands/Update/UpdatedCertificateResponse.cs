using Core.Application.Responses;

namespace Application.Features.Certificates.Commands.Update;

public class UpdatedCertificateResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Path { get; set; }
    public int Priority { get; set; }
}
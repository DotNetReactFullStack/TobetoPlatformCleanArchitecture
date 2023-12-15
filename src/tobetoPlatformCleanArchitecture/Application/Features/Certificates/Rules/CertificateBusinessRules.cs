using Application.Features.Certificates.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Certificates.Rules;

public class CertificateBusinessRules : BaseBusinessRules
{
    private readonly ICertificateRepository _certificateRepository;

    public CertificateBusinessRules(ICertificateRepository certificateRepository)
    {
        _certificateRepository = certificateRepository;
    }

    public Task CertificateShouldExistWhenSelected(Certificate? certificate)
    {
        if (certificate == null)
            throw new BusinessException(CertificatesBusinessMessages.CertificateNotExists);
        return Task.CompletedTask;
    }

    public async Task CertificateIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Certificate? certificate = await _certificateRepository.GetAsync(
            predicate: c => c.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CertificateShouldExistWhenSelected(certificate);
    }
}
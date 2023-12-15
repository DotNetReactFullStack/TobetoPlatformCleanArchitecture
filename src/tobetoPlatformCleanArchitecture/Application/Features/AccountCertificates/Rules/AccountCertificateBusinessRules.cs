using Application.Features.AccountCertificates.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.AccountCertificates.Rules;

public class AccountCertificateBusinessRules : BaseBusinessRules
{
    private readonly IAccountCertificateRepository _accountCertificateRepository;

    public AccountCertificateBusinessRules(IAccountCertificateRepository accountCertificateRepository)
    {
        _accountCertificateRepository = accountCertificateRepository;
    }

    public Task AccountCertificateShouldExistWhenSelected(AccountCertificate? accountCertificate)
    {
        if (accountCertificate == null)
            throw new BusinessException(AccountCertificatesBusinessMessages.AccountCertificateNotExists);
        return Task.CompletedTask;
    }

    public async Task AccountCertificateIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        AccountCertificate? accountCertificate = await _accountCertificateRepository.GetAsync(
            predicate: ac => ac.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await AccountCertificateShouldExistWhenSelected(accountCertificate);
    }
}
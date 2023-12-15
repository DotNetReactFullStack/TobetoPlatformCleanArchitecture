using Application.Features.AccountCertificates.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.AccountCertificates;

public class AccountCertificatesManager : IAccountCertificatesService
{
    private readonly IAccountCertificateRepository _accountCertificateRepository;
    private readonly AccountCertificateBusinessRules _accountCertificateBusinessRules;

    public AccountCertificatesManager(IAccountCertificateRepository accountCertificateRepository, AccountCertificateBusinessRules accountCertificateBusinessRules)
    {
        _accountCertificateRepository = accountCertificateRepository;
        _accountCertificateBusinessRules = accountCertificateBusinessRules;
    }

    public async Task<AccountCertificate?> GetAsync(
        Expression<Func<AccountCertificate, bool>> predicate,
        Func<IQueryable<AccountCertificate>, IIncludableQueryable<AccountCertificate, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        AccountCertificate? accountCertificate = await _accountCertificateRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return accountCertificate;
    }

    public async Task<IPaginate<AccountCertificate>?> GetListAsync(
        Expression<Func<AccountCertificate, bool>>? predicate = null,
        Func<IQueryable<AccountCertificate>, IOrderedQueryable<AccountCertificate>>? orderBy = null,
        Func<IQueryable<AccountCertificate>, IIncludableQueryable<AccountCertificate, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<AccountCertificate> accountCertificateList = await _accountCertificateRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return accountCertificateList;
    }

    public async Task<AccountCertificate> AddAsync(AccountCertificate accountCertificate)
    {
        AccountCertificate addedAccountCertificate = await _accountCertificateRepository.AddAsync(accountCertificate);

        return addedAccountCertificate;
    }

    public async Task<AccountCertificate> UpdateAsync(AccountCertificate accountCertificate)
    {
        AccountCertificate updatedAccountCertificate = await _accountCertificateRepository.UpdateAsync(accountCertificate);

        return updatedAccountCertificate;
    }

    public async Task<AccountCertificate> DeleteAsync(AccountCertificate accountCertificate, bool permanent = false)
    {
        AccountCertificate deletedAccountCertificate = await _accountCertificateRepository.DeleteAsync(accountCertificate);

        return deletedAccountCertificate;
    }
}

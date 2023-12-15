using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.AccountCertificates;

public interface IAccountCertificatesService
{
    Task<AccountCertificate?> GetAsync(
        Expression<Func<AccountCertificate, bool>> predicate,
        Func<IQueryable<AccountCertificate>, IIncludableQueryable<AccountCertificate, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<AccountCertificate>?> GetListAsync(
        Expression<Func<AccountCertificate, bool>>? predicate = null,
        Func<IQueryable<AccountCertificate>, IOrderedQueryable<AccountCertificate>>? orderBy = null,
        Func<IQueryable<AccountCertificate>, IIncludableQueryable<AccountCertificate, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<AccountCertificate> AddAsync(AccountCertificate accountCertificate);
    Task<AccountCertificate> UpdateAsync(AccountCertificate accountCertificate);
    Task<AccountCertificate> DeleteAsync(AccountCertificate accountCertificate, bool permanent = false);
}

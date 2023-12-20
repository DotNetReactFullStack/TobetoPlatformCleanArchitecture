using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.AccountAnnouncements;

public interface IAccountAnnouncementsService
{
    Task<AccountAnnouncement?> GetAsync(
        Expression<Func<AccountAnnouncement, bool>> predicate,
        Func<IQueryable<AccountAnnouncement>, IIncludableQueryable<AccountAnnouncement, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<AccountAnnouncement>?> GetListAsync(
        Expression<Func<AccountAnnouncement, bool>>? predicate = null,
        Func<IQueryable<AccountAnnouncement>, IOrderedQueryable<AccountAnnouncement>>? orderBy = null,
        Func<IQueryable<AccountAnnouncement>, IIncludableQueryable<AccountAnnouncement, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<AccountAnnouncement> AddAsync(AccountAnnouncement accountAnnouncement);
    Task<AccountAnnouncement> UpdateAsync(AccountAnnouncement accountAnnouncement);
    Task<AccountAnnouncement> DeleteAsync(AccountAnnouncement accountAnnouncement, bool permanent = false);
}

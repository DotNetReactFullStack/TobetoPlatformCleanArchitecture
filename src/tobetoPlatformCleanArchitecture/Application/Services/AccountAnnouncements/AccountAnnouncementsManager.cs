using Application.Features.AccountAnnouncements.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.AccountAnnouncements;

public class AccountAnnouncementsManager : IAccountAnnouncementsService
{
    private readonly IAccountAnnouncementRepository _accountAnnouncementRepository;
    private readonly AccountAnnouncementBusinessRules _accountAnnouncementBusinessRules;

    public AccountAnnouncementsManager(IAccountAnnouncementRepository accountAnnouncementRepository, AccountAnnouncementBusinessRules accountAnnouncementBusinessRules)
    {
        _accountAnnouncementRepository = accountAnnouncementRepository;
        _accountAnnouncementBusinessRules = accountAnnouncementBusinessRules;
    }

    public async Task<AccountAnnouncement?> GetAsync(
        Expression<Func<AccountAnnouncement, bool>> predicate,
        Func<IQueryable<AccountAnnouncement>, IIncludableQueryable<AccountAnnouncement, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        AccountAnnouncement? accountAnnouncement = await _accountAnnouncementRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return accountAnnouncement;
    }

    public async Task<IPaginate<AccountAnnouncement>?> GetListAsync(
        Expression<Func<AccountAnnouncement, bool>>? predicate = null,
        Func<IQueryable<AccountAnnouncement>, IOrderedQueryable<AccountAnnouncement>>? orderBy = null,
        Func<IQueryable<AccountAnnouncement>, IIncludableQueryable<AccountAnnouncement, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<AccountAnnouncement> accountAnnouncementList = await _accountAnnouncementRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return accountAnnouncementList;
    }

    public async Task<AccountAnnouncement> AddAsync(AccountAnnouncement accountAnnouncement)
    {
        AccountAnnouncement addedAccountAnnouncement = await _accountAnnouncementRepository.AddAsync(accountAnnouncement);

        return addedAccountAnnouncement;
    }

    public async Task<AccountAnnouncement> UpdateAsync(AccountAnnouncement accountAnnouncement)
    {
        AccountAnnouncement updatedAccountAnnouncement = await _accountAnnouncementRepository.UpdateAsync(accountAnnouncement);

        return updatedAccountAnnouncement;
    }

    public async Task<AccountAnnouncement> DeleteAsync(AccountAnnouncement accountAnnouncement, bool permanent = false)
    {
        AccountAnnouncement deletedAccountAnnouncement = await _accountAnnouncementRepository.DeleteAsync(accountAnnouncement);

        return deletedAccountAnnouncement;
    }
}

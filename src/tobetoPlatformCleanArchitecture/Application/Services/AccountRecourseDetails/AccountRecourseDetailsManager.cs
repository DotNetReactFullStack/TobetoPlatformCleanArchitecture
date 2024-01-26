using Application.Features.AccountRecourseDetails.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.AccountRecourseDetails;

public class AccountRecourseDetailsManager : IAccountRecourseDetailsService
{
    private readonly IAccountRecourseDetailRepository _accountRecourseDetailRepository;
    private readonly AccountRecourseDetailBusinessRules _accountRecourseDetailBusinessRules;

    public AccountRecourseDetailsManager(IAccountRecourseDetailRepository accountRecourseDetailRepository, AccountRecourseDetailBusinessRules accountRecourseDetailBusinessRules)
    {
        _accountRecourseDetailRepository = accountRecourseDetailRepository;
        _accountRecourseDetailBusinessRules = accountRecourseDetailBusinessRules;
    }

    public async Task<AccountRecourseDetail?> GetAsync(
        Expression<Func<AccountRecourseDetail, bool>> predicate,
        Func<IQueryable<AccountRecourseDetail>, IIncludableQueryable<AccountRecourseDetail, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        AccountRecourseDetail? accountRecourseDetail = await _accountRecourseDetailRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return accountRecourseDetail;
    }

    public async Task<IPaginate<AccountRecourseDetail>?> GetListAsync(
        Expression<Func<AccountRecourseDetail, bool>>? predicate = null,
        Func<IQueryable<AccountRecourseDetail>, IOrderedQueryable<AccountRecourseDetail>>? orderBy = null,
        Func<IQueryable<AccountRecourseDetail>, IIncludableQueryable<AccountRecourseDetail, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<AccountRecourseDetail> accountRecourseDetailList = await _accountRecourseDetailRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return accountRecourseDetailList;
    }

    public async Task<AccountRecourseDetail> AddAsync(AccountRecourseDetail accountRecourseDetail)
    {
        AccountRecourseDetail addedAccountRecourseDetail = await _accountRecourseDetailRepository.AddAsync(accountRecourseDetail);

        return addedAccountRecourseDetail;
    }

    public async Task<AccountRecourseDetail> UpdateAsync(AccountRecourseDetail accountRecourseDetail)
    {
        AccountRecourseDetail updatedAccountRecourseDetail = await _accountRecourseDetailRepository.UpdateAsync(accountRecourseDetail);

        return updatedAccountRecourseDetail;
    }

    public async Task<AccountRecourseDetail> DeleteAsync(AccountRecourseDetail accountRecourseDetail, bool permanent = false)
    {
        AccountRecourseDetail deletedAccountRecourseDetail = await _accountRecourseDetailRepository.DeleteAsync(accountRecourseDetail);

        return deletedAccountRecourseDetail;
    }
}

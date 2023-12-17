using Application.Features.Recourses.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Recourses;

public class RecoursesManager : IRecoursesService
{
    private readonly IRecourseRepository _recourseRepository;
    private readonly RecourseBusinessRules _recourseBusinessRules;

    public RecoursesManager(IRecourseRepository recourseRepository, RecourseBusinessRules recourseBusinessRules)
    {
        _recourseRepository = recourseRepository;
        _recourseBusinessRules = recourseBusinessRules;
    }

    public async Task<Recourse?> GetAsync(
        Expression<Func<Recourse, bool>> predicate,
        Func<IQueryable<Recourse>, IIncludableQueryable<Recourse, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Recourse? recourse = await _recourseRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return recourse;
    }

    public async Task<IPaginate<Recourse>?> GetListAsync(
        Expression<Func<Recourse, bool>>? predicate = null,
        Func<IQueryable<Recourse>, IOrderedQueryable<Recourse>>? orderBy = null,
        Func<IQueryable<Recourse>, IIncludableQueryable<Recourse, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Recourse> recourseList = await _recourseRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return recourseList;
    }

    public async Task<Recourse> AddAsync(Recourse recourse)
    {
        Recourse addedRecourse = await _recourseRepository.AddAsync(recourse);

        return addedRecourse;
    }

    public async Task<Recourse> UpdateAsync(Recourse recourse)
    {
        Recourse updatedRecourse = await _recourseRepository.UpdateAsync(recourse);

        return updatedRecourse;
    }

    public async Task<Recourse> DeleteAsync(Recourse recourse, bool permanent = false)
    {
        Recourse deletedRecourse = await _recourseRepository.DeleteAsync(recourse);

        return deletedRecourse;
    }
}

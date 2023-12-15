using Application.Features.Colleges.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Colleges;

public class CollegesManager : ICollegesService
{
    private readonly ICollegeRepository _collegeRepository;
    private readonly CollegeBusinessRules _collegeBusinessRules;

    public CollegesManager(ICollegeRepository collegeRepository, CollegeBusinessRules collegeBusinessRules)
    {
        _collegeRepository = collegeRepository;
        _collegeBusinessRules = collegeBusinessRules;
    }

    public async Task<College?> GetAsync(
        Expression<Func<College, bool>> predicate,
        Func<IQueryable<College>, IIncludableQueryable<College, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        College? college = await _collegeRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return college;
    }

    public async Task<IPaginate<College>?> GetListAsync(
        Expression<Func<College, bool>>? predicate = null,
        Func<IQueryable<College>, IOrderedQueryable<College>>? orderBy = null,
        Func<IQueryable<College>, IIncludableQueryable<College, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<College> collegeList = await _collegeRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return collegeList;
    }

    public async Task<College> AddAsync(College college)
    {
        College addedCollege = await _collegeRepository.AddAsync(college);

        return addedCollege;
    }

    public async Task<College> UpdateAsync(College college)
    {
        College updatedCollege = await _collegeRepository.UpdateAsync(college);

        return updatedCollege;
    }

    public async Task<College> DeleteAsync(College college, bool permanent = false)
    {
        College deletedCollege = await _collegeRepository.DeleteAsync(college);

        return deletedCollege;
    }
}

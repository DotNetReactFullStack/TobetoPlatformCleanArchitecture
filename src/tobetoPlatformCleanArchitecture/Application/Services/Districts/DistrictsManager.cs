using Application.Features.Districts.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Districts;

public class DistrictsManager : IDistrictsService
{
    private readonly IDistrictRepository _districtRepository;
    private readonly DistrictBusinessRules _districtBusinessRules;

    public DistrictsManager(IDistrictRepository districtRepository, DistrictBusinessRules districtBusinessRules)
    {
        _districtRepository = districtRepository;
        _districtBusinessRules = districtBusinessRules;
    }

    public async Task<District?> GetAsync(
        Expression<Func<District, bool>> predicate,
        Func<IQueryable<District>, IIncludableQueryable<District, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        District? district = await _districtRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return district;
    }

    public async Task<IPaginate<District>?> GetListAsync(
        Expression<Func<District, bool>>? predicate = null,
        Func<IQueryable<District>, IOrderedQueryable<District>>? orderBy = null,
        Func<IQueryable<District>, IIncludableQueryable<District, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<District> districtList = await _districtRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return districtList;
    }

    public async Task<District> AddAsync(District district)
    {
        District addedDistrict = await _districtRepository.AddAsync(district);

        return addedDistrict;
    }

    public async Task<District> UpdateAsync(District district)
    {
        District updatedDistrict = await _districtRepository.UpdateAsync(district);

        return updatedDistrict;
    }

    public async Task<District> DeleteAsync(District district, bool permanent = false)
    {
        District deletedDistrict = await _districtRepository.DeleteAsync(district);

        return deletedDistrict;
    }
}

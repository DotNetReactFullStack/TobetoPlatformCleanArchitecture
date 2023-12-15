using Application.Features.Cities.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Cities;

public class CitiesManager : ICitiesService
{
    private readonly ICityRepository _cityRepository;
    private readonly CityBusinessRules _cityBusinessRules;

    public CitiesManager(ICityRepository cityRepository, CityBusinessRules cityBusinessRules)
    {
        _cityRepository = cityRepository;
        _cityBusinessRules = cityBusinessRules;
    }

    public async Task<City?> GetAsync(
        Expression<Func<City, bool>> predicate,
        Func<IQueryable<City>, IIncludableQueryable<City, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        City? city = await _cityRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return city;
    }

    public async Task<IPaginate<City>?> GetListAsync(
        Expression<Func<City, bool>>? predicate = null,
        Func<IQueryable<City>, IOrderedQueryable<City>>? orderBy = null,
        Func<IQueryable<City>, IIncludableQueryable<City, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<City> cityList = await _cityRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return cityList;
    }

    public async Task<City> AddAsync(City city)
    {
        City addedCity = await _cityRepository.AddAsync(city);

        return addedCity;
    }

    public async Task<City> UpdateAsync(City city)
    {
        City updatedCity = await _cityRepository.UpdateAsync(city);

        return updatedCity;
    }

    public async Task<City> DeleteAsync(City city, bool permanent = false)
    {
        City deletedCity = await _cityRepository.DeleteAsync(city);

        return deletedCity;
    }
}

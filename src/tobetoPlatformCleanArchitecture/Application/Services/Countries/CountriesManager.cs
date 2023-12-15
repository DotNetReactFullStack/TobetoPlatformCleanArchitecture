using Application.Features.Countries.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Countries;

public class CountriesManager : ICountriesService
{
    private readonly ICountryRepository _countryRepository;
    private readonly CountryBusinessRules _countryBusinessRules;

    public CountriesManager(ICountryRepository countryRepository, CountryBusinessRules countryBusinessRules)
    {
        _countryRepository = countryRepository;
        _countryBusinessRules = countryBusinessRules;
    }

    public async Task<Country?> GetAsync(
        Expression<Func<Country, bool>> predicate,
        Func<IQueryable<Country>, IIncludableQueryable<Country, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Country? country = await _countryRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return country;
    }

    public async Task<IPaginate<Country>?> GetListAsync(
        Expression<Func<Country, bool>>? predicate = null,
        Func<IQueryable<Country>, IOrderedQueryable<Country>>? orderBy = null,
        Func<IQueryable<Country>, IIncludableQueryable<Country, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Country> countryList = await _countryRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return countryList;
    }

    public async Task<Country> AddAsync(Country country)
    {
        Country addedCountry = await _countryRepository.AddAsync(country);

        return addedCountry;
    }

    public async Task<Country> UpdateAsync(Country country)
    {
        Country updatedCountry = await _countryRepository.UpdateAsync(country);

        return updatedCountry;
    }

    public async Task<Country> DeleteAsync(Country country, bool permanent = false)
    {
        Country deletedCountry = await _countryRepository.DeleteAsync(country);

        return deletedCountry;
    }
}

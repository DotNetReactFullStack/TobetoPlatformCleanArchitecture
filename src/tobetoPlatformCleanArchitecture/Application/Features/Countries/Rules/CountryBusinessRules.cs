using Application.Features.Countries.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Countries.Rules;

public class CountryBusinessRules : BaseBusinessRules
{
    private readonly ICountryRepository _countryRepository;

    public CountryBusinessRules(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }

    public Task CountryShouldExistWhenSelected(Country? country)
    {
        if (country == null)
            throw new BusinessException(CountriesBusinessMessages.CountryNotExists);
        return Task.CompletedTask;
    }

    public async Task CountryIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Country? country = await _countryRepository.GetAsync(
            predicate: c => c.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CountryShouldExistWhenSelected(country);
    }
}
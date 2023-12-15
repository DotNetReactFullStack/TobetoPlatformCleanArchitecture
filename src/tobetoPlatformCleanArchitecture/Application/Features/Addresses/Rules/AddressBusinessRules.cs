using Application.Features.Addresses.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Addresses.Rules;

public class AddressBusinessRules : BaseBusinessRules
{
    private readonly IAddressRepository _addressRepository;

    public AddressBusinessRules(IAddressRepository addressRepository)
    {
        _addressRepository = addressRepository;
    }

    public Task AddressShouldExistWhenSelected(Address? address)
    {
        if (address == null)
            throw new BusinessException(AddressesBusinessMessages.AddressNotExists);
        return Task.CompletedTask;
    }

    public async Task AddressIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Address? address = await _addressRepository.GetAsync(
            predicate: a => a.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await AddressShouldExistWhenSelected(address);
    }
}
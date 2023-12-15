using Application.Features.Addresses.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Addresses;

public class AddressesManager : IAddressesService
{
    private readonly IAddressRepository _addressRepository;
    private readonly AddressBusinessRules _addressBusinessRules;

    public AddressesManager(IAddressRepository addressRepository, AddressBusinessRules addressBusinessRules)
    {
        _addressRepository = addressRepository;
        _addressBusinessRules = addressBusinessRules;
    }

    public async Task<Address?> GetAsync(
        Expression<Func<Address, bool>> predicate,
        Func<IQueryable<Address>, IIncludableQueryable<Address, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Address? address = await _addressRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return address;
    }

    public async Task<IPaginate<Address>?> GetListAsync(
        Expression<Func<Address, bool>>? predicate = null,
        Func<IQueryable<Address>, IOrderedQueryable<Address>>? orderBy = null,
        Func<IQueryable<Address>, IIncludableQueryable<Address, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Address> addressList = await _addressRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return addressList;
    }

    public async Task<Address> AddAsync(Address address)
    {
        Address addedAddress = await _addressRepository.AddAsync(address);

        return addedAddress;
    }

    public async Task<Address> UpdateAsync(Address address)
    {
        Address updatedAddress = await _addressRepository.UpdateAsync(address);

        return updatedAddress;
    }

    public async Task<Address> DeleteAsync(Address address, bool permanent = false)
    {
        Address deletedAddress = await _addressRepository.DeleteAsync(address);

        return deletedAddress;
    }
}

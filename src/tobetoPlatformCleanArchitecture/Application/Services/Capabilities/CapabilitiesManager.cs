using Application.Features.Capabilities.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Capabilities;

public class CapabilitiesManager : ICapabilitiesService
{
    private readonly ICapabilityRepository _capabilityRepository;
    private readonly CapabilityBusinessRules _capabilityBusinessRules;

    public CapabilitiesManager(ICapabilityRepository capabilityRepository, CapabilityBusinessRules capabilityBusinessRules)
    {
        _capabilityRepository = capabilityRepository;
        _capabilityBusinessRules = capabilityBusinessRules;
    }

    public async Task<Capability?> GetAsync(
        Expression<Func<Capability, bool>> predicate,
        Func<IQueryable<Capability>, IIncludableQueryable<Capability, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Capability? capability = await _capabilityRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return capability;
    }

    public async Task<IPaginate<Capability>?> GetListAsync(
        Expression<Func<Capability, bool>>? predicate = null,
        Func<IQueryable<Capability>, IOrderedQueryable<Capability>>? orderBy = null,
        Func<IQueryable<Capability>, IIncludableQueryable<Capability, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Capability> capabilityList = await _capabilityRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return capabilityList;
    }

    public async Task<Capability> AddAsync(Capability capability)
    {
        Capability addedCapability = await _capabilityRepository.AddAsync(capability);

        return addedCapability;
    }

    public async Task<Capability> UpdateAsync(Capability capability)
    {
        Capability updatedCapability = await _capabilityRepository.UpdateAsync(capability);

        return updatedCapability;
    }

    public async Task<Capability> DeleteAsync(Capability capability, bool permanent = false)
    {
        Capability deletedCapability = await _capabilityRepository.DeleteAsync(capability);

        return deletedCapability;
    }
}

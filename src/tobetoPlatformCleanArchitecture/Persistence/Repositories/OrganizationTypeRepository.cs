using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class OrganizationTypeRepository : EfRepositoryBase<OrganizationType, int, TobetoPlatformDbContext>, IOrganizationTypeRepository
{
    public OrganizationTypeRepository(TobetoPlatformDbContext context) : base(context)
    {
    }
}
using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class OrganizationTypeRepository : EfRepositoryBase<OrganizationType, int, BaseDbContext>, IOrganizationTypeRepository
{
    public OrganizationTypeRepository(BaseDbContext context) : base(context)
    {
    }
}
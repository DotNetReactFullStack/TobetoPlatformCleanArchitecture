using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class OrganizationRepository : EfRepositoryBase<Organization, int, BaseDbContext>, IOrganizationRepository
{
    public OrganizationRepository(BaseDbContext context) : base(context)
    {
    }
}
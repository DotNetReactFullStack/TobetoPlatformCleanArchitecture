using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class OrganizationRepository : EfRepositoryBase<Organization, int, TobetoPlatformDbContext>, IOrganizationRepository
{
    public OrganizationRepository(TobetoPlatformDbContext context) : base(context)
    {
    }
}
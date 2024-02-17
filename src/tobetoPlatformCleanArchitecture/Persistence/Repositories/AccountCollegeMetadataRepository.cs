using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class AccountCollegeMetadataRepository : EfRepositoryBase<AccountCollegeMetadata, int, BaseDbContext>, IAccountCollegeMetadataRepository
{
    public AccountCollegeMetadataRepository(BaseDbContext context) : base(context)
    {
    }
}
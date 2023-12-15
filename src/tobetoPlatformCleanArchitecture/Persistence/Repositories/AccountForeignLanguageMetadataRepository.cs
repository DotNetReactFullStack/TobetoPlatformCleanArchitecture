using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class AccountForeignLanguageMetadataRepository : EfRepositoryBase<AccountForeignLanguageMetadata, int, BaseDbContext>, IAccountForeignLanguageMetadataRepository
{
    public AccountForeignLanguageMetadataRepository(BaseDbContext context) : base(context)
    {
    }
}
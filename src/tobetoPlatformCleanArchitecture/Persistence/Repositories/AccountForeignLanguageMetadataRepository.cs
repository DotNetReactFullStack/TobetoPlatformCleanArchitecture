using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class AccountForeignLanguageMetadataRepository : EfRepositoryBase<AccountForeignLanguageMetadata, int, TobetoPlatformDbContext>, IAccountForeignLanguageMetadataRepository
{
    public AccountForeignLanguageMetadataRepository(TobetoPlatformDbContext context) : base(context)
    {
    }
}
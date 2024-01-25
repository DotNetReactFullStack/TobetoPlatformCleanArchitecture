using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class AccountCollageMetadataRepository : EfRepositoryBase<AccountCollageMetadata, int, TobetoPlatformDbContext>, IAccountCollageMetadataRepository
{
    public AccountCollageMetadataRepository(TobetoPlatformDbContext context) : base(context)
    {
    }
}
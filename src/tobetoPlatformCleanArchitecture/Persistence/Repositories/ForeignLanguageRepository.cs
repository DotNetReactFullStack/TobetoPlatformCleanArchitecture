using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ForeignLanguageRepository : EfRepositoryBase<ForeignLanguage, int, TobetoPlatformDbContext>, IForeignLanguageRepository
{
    public ForeignLanguageRepository(TobetoPlatformDbContext context) : base(context)
    {
    }
}
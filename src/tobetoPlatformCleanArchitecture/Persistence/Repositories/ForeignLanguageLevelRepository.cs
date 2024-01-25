using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ForeignLanguageLevelRepository : EfRepositoryBase<ForeignLanguageLevel, int, TobetoPlatformDbContext>, IForeignLanguageLevelRepository
{
    public ForeignLanguageLevelRepository(TobetoPlatformDbContext context) : base(context)
    {
    }
}
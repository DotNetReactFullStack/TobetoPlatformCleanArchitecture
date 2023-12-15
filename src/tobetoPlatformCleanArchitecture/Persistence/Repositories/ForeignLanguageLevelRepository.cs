using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ForeignLanguageLevelRepository : EfRepositoryBase<ForeignLanguageLevel, int, BaseDbContext>, IForeignLanguageLevelRepository
{
    public ForeignLanguageLevelRepository(BaseDbContext context) : base(context)
    {
    }
}
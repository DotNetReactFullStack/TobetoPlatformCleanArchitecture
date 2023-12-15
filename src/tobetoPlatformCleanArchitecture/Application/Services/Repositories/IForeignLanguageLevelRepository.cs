using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IForeignLanguageLevelRepository : IAsyncRepository<ForeignLanguageLevel, int>, IRepository<ForeignLanguageLevel, int>
{
}
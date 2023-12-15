using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IForeignLanguageRepository : IAsyncRepository<ForeignLanguage, int>, IRepository<ForeignLanguage, int>
{
}
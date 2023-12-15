using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IAccountForeignLanguageMetadataRepository : IAsyncRepository<AccountForeignLanguageMetadata, int>, IRepository<AccountForeignLanguageMetadata, int>
{
}
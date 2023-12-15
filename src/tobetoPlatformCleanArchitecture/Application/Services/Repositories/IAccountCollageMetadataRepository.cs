using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IAccountCollageMetadataRepository : IAsyncRepository<AccountCollageMetadata, int>, IRepository<AccountCollageMetadata, int>
{
}
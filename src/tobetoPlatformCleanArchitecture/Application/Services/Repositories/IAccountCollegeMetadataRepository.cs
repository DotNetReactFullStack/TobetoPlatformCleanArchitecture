using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IAccountCollegeMetadataRepository : IAsyncRepository<AccountCollegeMetadata, int>, IRepository<AccountCollegeMetadata, int>
{
}
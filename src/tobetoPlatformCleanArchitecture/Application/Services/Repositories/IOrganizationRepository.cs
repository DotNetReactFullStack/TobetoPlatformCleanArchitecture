using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IOrganizationRepository : IAsyncRepository<Organization, int>, IRepository<Organization, int>
{
}
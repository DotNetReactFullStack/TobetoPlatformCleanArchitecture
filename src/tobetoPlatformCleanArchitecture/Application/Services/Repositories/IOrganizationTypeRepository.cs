using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IOrganizationTypeRepository : IAsyncRepository<OrganizationType, int>, IRepository<OrganizationType, int>
{
}
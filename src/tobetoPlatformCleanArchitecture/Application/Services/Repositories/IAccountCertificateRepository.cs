using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IAccountCertificateRepository : IAsyncRepository<AccountCertificate, int>, IRepository<AccountCertificate, int>
{
}
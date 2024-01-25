using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class AccountCertificateRepository : EfRepositoryBase<AccountCertificate, int, TobetoPlatformDbContext>, IAccountCertificateRepository
{
    public AccountCertificateRepository(TobetoPlatformDbContext context) : base(context)
    {
    }
}
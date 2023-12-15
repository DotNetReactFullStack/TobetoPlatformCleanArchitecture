using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CertificateRepository : EfRepositoryBase<Certificate, int, BaseDbContext>, ICertificateRepository
{
    public CertificateRepository(BaseDbContext context) : base(context)
    {
    }
}
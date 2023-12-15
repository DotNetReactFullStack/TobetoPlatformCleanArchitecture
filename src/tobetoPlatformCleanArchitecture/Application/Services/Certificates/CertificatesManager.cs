using Application.Features.Certificates.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Certificates;

public class CertificatesManager : ICertificatesService
{
    private readonly ICertificateRepository _certificateRepository;
    private readonly CertificateBusinessRules _certificateBusinessRules;

    public CertificatesManager(ICertificateRepository certificateRepository, CertificateBusinessRules certificateBusinessRules)
    {
        _certificateRepository = certificateRepository;
        _certificateBusinessRules = certificateBusinessRules;
    }

    public async Task<Certificate?> GetAsync(
        Expression<Func<Certificate, bool>> predicate,
        Func<IQueryable<Certificate>, IIncludableQueryable<Certificate, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Certificate? certificate = await _certificateRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return certificate;
    }

    public async Task<IPaginate<Certificate>?> GetListAsync(
        Expression<Func<Certificate, bool>>? predicate = null,
        Func<IQueryable<Certificate>, IOrderedQueryable<Certificate>>? orderBy = null,
        Func<IQueryable<Certificate>, IIncludableQueryable<Certificate, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Certificate> certificateList = await _certificateRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return certificateList;
    }

    public async Task<Certificate> AddAsync(Certificate certificate)
    {
        Certificate addedCertificate = await _certificateRepository.AddAsync(certificate);

        return addedCertificate;
    }

    public async Task<Certificate> UpdateAsync(Certificate certificate)
    {
        Certificate updatedCertificate = await _certificateRepository.UpdateAsync(certificate);

        return updatedCertificate;
    }

    public async Task<Certificate> DeleteAsync(Certificate certificate, bool permanent = false)
    {
        Certificate deletedCertificate = await _certificateRepository.DeleteAsync(certificate);

        return deletedCertificate;
    }
}

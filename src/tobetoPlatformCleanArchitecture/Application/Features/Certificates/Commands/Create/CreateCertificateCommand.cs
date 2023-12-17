using Application.Features.Certificates.Constants;
using Application.Features.Certificates.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Certificates.Constants.CertificatesOperationClaims;

namespace Application.Features.Certificates.Commands.Create;

public class CreateCertificateCommand : IRequest<CreatedCertificateResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string Name { get; set; }
    public string Path { get; set; }
    public int Priority { get; set; }

    public string[] Roles => new[] { Admin, Write, CertificatesOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetCertificates";

    public class CreateCertificateCommandHandler : IRequestHandler<CreateCertificateCommand, CreatedCertificateResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICertificateRepository _certificateRepository;
        private readonly CertificateBusinessRules _certificateBusinessRules;

        public CreateCertificateCommandHandler(IMapper mapper, ICertificateRepository certificateRepository,
                                         CertificateBusinessRules certificateBusinessRules)
        {
            _mapper = mapper;
            _certificateRepository = certificateRepository;
            _certificateBusinessRules = certificateBusinessRules;
        }

        public async Task<CreatedCertificateResponse> Handle(CreateCertificateCommand request, CancellationToken cancellationToken)
        {
            Certificate certificate = _mapper.Map<Certificate>(request);

            await _certificateRepository.AddAsync(certificate);

            CreatedCertificateResponse response = _mapper.Map<CreatedCertificateResponse>(certificate);
            return response;
        }
    }
}
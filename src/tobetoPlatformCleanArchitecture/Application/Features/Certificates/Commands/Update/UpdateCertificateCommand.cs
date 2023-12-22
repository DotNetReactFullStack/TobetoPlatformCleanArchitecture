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

namespace Application.Features.Certificates.Commands.Update;

public class UpdateCertificateCommand : IRequest<UpdatedCertificateResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Path { get; set; }
    public int Priority { get; set; }

    public string[] Roles => new[] { Admin, Write, CertificatesOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetCertificates";

    public class UpdateCertificateCommandHandler : IRequestHandler<UpdateCertificateCommand, UpdatedCertificateResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICertificateRepository _certificateRepository;
        private readonly CertificateBusinessRules _certificateBusinessRules;

        public UpdateCertificateCommandHandler(IMapper mapper, ICertificateRepository certificateRepository,
                                         CertificateBusinessRules certificateBusinessRules)
        {
            _mapper = mapper;
            _certificateRepository = certificateRepository;
            _certificateBusinessRules = certificateBusinessRules;
        }

        public async Task<UpdatedCertificateResponse> Handle(UpdateCertificateCommand request, CancellationToken cancellationToken)
        {
            Certificate? certificate = await _certificateRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _certificateBusinessRules.CertificateShouldExistWhenSelected(certificate);
            certificate = _mapper.Map(request, certificate);

            await _certificateRepository.UpdateAsync(certificate!);

            UpdatedCertificateResponse response = _mapper.Map<UpdatedCertificateResponse>(certificate);
            return response;
        }
    }
}
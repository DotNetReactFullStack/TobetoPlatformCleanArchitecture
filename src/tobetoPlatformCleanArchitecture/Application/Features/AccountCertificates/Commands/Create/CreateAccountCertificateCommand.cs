using Application.Features.AccountCertificates.Constants;
using Application.Features.AccountCertificates.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.AccountCertificates.Constants.AccountCertificatesOperationClaims;

namespace Application.Features.AccountCertificates.Commands.Create;

public class CreateAccountCertificateCommand : IRequest<CreatedAccountCertificateResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int AccountId { get; set; }
    public int CertificateId { get; set; }
    public int Priority { get; set; }

    public string[] Roles => new[] { Admin, Write, AccountCertificatesOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetAccountCertificates";

    public class CreateAccountCertificateCommandHandler : IRequestHandler<CreateAccountCertificateCommand, CreatedAccountCertificateResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountCertificateRepository _accountCertificateRepository;
        private readonly AccountCertificateBusinessRules _accountCertificateBusinessRules;

        public CreateAccountCertificateCommandHandler(IMapper mapper, IAccountCertificateRepository accountCertificateRepository,
                                         AccountCertificateBusinessRules accountCertificateBusinessRules)
        {
            _mapper = mapper;
            _accountCertificateRepository = accountCertificateRepository;
            _accountCertificateBusinessRules = accountCertificateBusinessRules;
        }

        public async Task<CreatedAccountCertificateResponse> Handle(CreateAccountCertificateCommand request, CancellationToken cancellationToken)
        {
            AccountCertificate accountCertificate = _mapper.Map<AccountCertificate>(request);

            await _accountCertificateRepository.AddAsync(accountCertificate);

            CreatedAccountCertificateResponse response = _mapper.Map<CreatedAccountCertificateResponse>(accountCertificate);
            return response;
        }
    }
}
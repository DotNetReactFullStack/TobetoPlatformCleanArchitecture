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

namespace Application.Features.AccountCertificates.Commands.Update;

public class UpdateAccountCertificateCommand : IRequest<UpdatedAccountCertificateResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public int CertificateId { get; set; }
    public int Priority { get; set; }

    public string[] Roles => new[] { Admin, Write, AccountCertificatesOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetAccountCertificates";

    public class UpdateAccountCertificateCommandHandler : IRequestHandler<UpdateAccountCertificateCommand, UpdatedAccountCertificateResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountCertificateRepository _accountCertificateRepository;
        private readonly AccountCertificateBusinessRules _accountCertificateBusinessRules;

        public UpdateAccountCertificateCommandHandler(IMapper mapper, IAccountCertificateRepository accountCertificateRepository,
                                         AccountCertificateBusinessRules accountCertificateBusinessRules)
        {
            _mapper = mapper;
            _accountCertificateRepository = accountCertificateRepository;
            _accountCertificateBusinessRules = accountCertificateBusinessRules;
        }

        public async Task<UpdatedAccountCertificateResponse> Handle(UpdateAccountCertificateCommand request, CancellationToken cancellationToken)
        {
            AccountCertificate? accountCertificate = await _accountCertificateRepository.GetAsync(predicate: ac => ac.Id == request.Id, cancellationToken: cancellationToken);
            await _accountCertificateBusinessRules.AccountCertificateShouldExistWhenSelected(accountCertificate);
            accountCertificate = _mapper.Map(request, accountCertificate);

            await _accountCertificateRepository.UpdateAsync(accountCertificate!);

            UpdatedAccountCertificateResponse response = _mapper.Map<UpdatedAccountCertificateResponse>(accountCertificate);
            return response;
        }
    }
}
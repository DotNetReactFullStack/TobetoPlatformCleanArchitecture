using Application.Features.AccountCertificates.Constants;
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

namespace Application.Features.AccountCertificates.Commands.Delete;

public class DeleteAccountCertificateCommand : IRequest<DeletedAccountCertificateResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, AccountCertificatesOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetAccountCertificates";

    public class DeleteAccountCertificateCommandHandler : IRequestHandler<DeleteAccountCertificateCommand, DeletedAccountCertificateResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountCertificateRepository _accountCertificateRepository;
        private readonly AccountCertificateBusinessRules _accountCertificateBusinessRules;

        public DeleteAccountCertificateCommandHandler(IMapper mapper, IAccountCertificateRepository accountCertificateRepository,
                                         AccountCertificateBusinessRules accountCertificateBusinessRules)
        {
            _mapper = mapper;
            _accountCertificateRepository = accountCertificateRepository;
            _accountCertificateBusinessRules = accountCertificateBusinessRules;
        }

        public async Task<DeletedAccountCertificateResponse> Handle(DeleteAccountCertificateCommand request, CancellationToken cancellationToken)
        {
            AccountCertificate? accountCertificate = await _accountCertificateRepository.GetAsync(predicate: ac => ac.Id == request.Id, cancellationToken: cancellationToken);
            await _accountCertificateBusinessRules.AccountCertificateShouldExistWhenSelected(accountCertificate);

            await _accountCertificateRepository.DeleteAsync(accountCertificate!);

            DeletedAccountCertificateResponse response = _mapper.Map<DeletedAccountCertificateResponse>(accountCertificate);
            return response;
        }
    }
}
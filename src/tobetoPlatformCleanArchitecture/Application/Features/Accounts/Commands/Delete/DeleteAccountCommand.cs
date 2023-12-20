using Application.Features.Accounts.Constants;
using Application.Features.Accounts.Constants;
using Application.Features.Accounts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Accounts.Constants.AccountsOperationClaims;

namespace Application.Features.Accounts.Commands.Delete;

public class DeleteAccountCommand : IRequest<DeletedAccountResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, AccountsOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetAccounts";

    public class DeleteAccountCommandHandler : IRequestHandler<DeleteAccountCommand, DeletedAccountResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountRepository _accountRepository;
        private readonly AccountBusinessRules _accountBusinessRules;

        public DeleteAccountCommandHandler(IMapper mapper, IAccountRepository accountRepository,
                                         AccountBusinessRules accountBusinessRules)
        {
            _mapper = mapper;
            _accountRepository = accountRepository;
            _accountBusinessRules = accountBusinessRules;
        }

        public async Task<DeletedAccountResponse> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            Account? account = await _accountRepository.GetAsync(predicate: a => a.Id == request.Id, cancellationToken: cancellationToken);
            await _accountBusinessRules.AccountShouldExistWhenSelected(account);

            await _accountRepository.DeleteAsync(account!);

            DeletedAccountResponse response = _mapper.Map<DeletedAccountResponse>(account);
            return response;
        }
    }
}
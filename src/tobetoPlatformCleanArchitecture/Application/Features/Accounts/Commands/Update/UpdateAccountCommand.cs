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
using Application.Features.OperationClaims.Constants;

namespace Application.Features.Accounts.Commands.Update;

public class UpdateAccountCommand : IRequest<UpdatedAccountResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public string AboutMe { get; set; }
    public DateTime BirthDate { get; set; }
    public string PhoneNumber { get; set; }
    public string? ProfilePhotoPath { get; set; }
    public bool ShareProfile { get; set; }
    public string ProfileLinkUrl { get; set; }
    public bool IsActive { get; set; }
    public int? UserIdForCheck { get; set; }

    public string[] Roles => new[] { Admin, Write, AccountsOperationClaims.Update, GeneralOperationClaims.Instructor, GeneralOperationClaims.Student };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetAccounts";

    public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand, UpdatedAccountResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountRepository _accountRepository;
        private readonly AccountBusinessRules _accountBusinessRules;

        public UpdateAccountCommandHandler(IMapper mapper, IAccountRepository accountRepository,
                                         AccountBusinessRules accountBusinessRules)
        {
            _mapper = mapper;
            _accountRepository = accountRepository;
            _accountBusinessRules = accountBusinessRules;
        }

        public async Task<UpdatedAccountResponse> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
        {
            Account? account = await _accountRepository.GetAsync(predicate: a => a.Id == request.Id, cancellationToken: cancellationToken);
            await _accountBusinessRules.AccountShouldExistWhenSelected(account);
            account = _mapper.Map(request, account);

            _accountBusinessRules.UserCanOnlyUpdateTheirOwnAccount(account: account, userIdForCheck: request.UserIdForCheck);

            await _accountRepository.UpdateAsync(account!);

            UpdatedAccountResponse response = _mapper.Map<UpdatedAccountResponse>(account);
            return response;
        }
    }
}
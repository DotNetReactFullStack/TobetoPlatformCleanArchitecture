using Application.Features.Accounts.Constants;
using Application.Features.Accounts.Rules;
using Application.Features.Addresses.Constants;
using Application.Features.OperationClaims.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.Features.Accounts.Constants.AccountsOperationClaims;

namespace Application.Features.Accounts.Commands.Update.UpdateAccountInformation;
public class UpdateAccountInformationCommand : IRequest<UpdatedAccountResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int AccountId { get; set; }
    public string AboutMe { get; set; }
    public DateTime BirthDate { get; set; }
    public string PhoneNumber { get; set; }

    public string[] Roles => new[] { Admin, Write, AccountsOperationClaims.Update, GeneralOperationClaims.Instructor, GeneralOperationClaims.Student };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetAccounts";
    public class UpdateAccountInformationCommandHandler : IRequestHandler<UpdateAccountInformationCommand, UpdatedAccountResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountRepository _accountRepository;
        private readonly AccountBusinessRules _accountBusinessRules;

        public UpdateAccountInformationCommandHandler(IMapper mapper, IAccountRepository accountRepository,
                                         AccountBusinessRules accountBusinessRules)
        {
            _mapper = mapper;
            _accountRepository = accountRepository;
            _accountBusinessRules = accountBusinessRules;
        }

        public async Task<UpdatedAccountResponse> Handle(UpdateAccountInformationCommand request, CancellationToken cancellationToken)
        {
            Account? account = await _accountRepository.GetAsync(predicate: a => a.Id == request.AccountId, cancellationToken: cancellationToken);
            await _accountBusinessRules.AccountShouldExistWhenSelected(account);
            account = _mapper.Map(request, account);

            //_accountBusinessRules.UserCanOnlyUpdateTheirOwnAccount(account: account, userIdForCheck: request.UserIdForCheck);

            await _accountRepository.UpdateAsync(account!);

            UpdatedAccountResponse response = _mapper.Map<UpdatedAccountResponse>(account);
            return response;
        }
    }
}

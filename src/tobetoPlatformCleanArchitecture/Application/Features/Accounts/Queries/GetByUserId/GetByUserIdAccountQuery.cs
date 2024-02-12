using Application.Features.Accounts.Rules;
using Application.Features.OperationClaims.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using MediatR;
using System;

using static Application.Features.Accounts.Constants.AccountsOperationClaims;

namespace Application.Features.Accounts.Queries.GetByUserId
{
    public class GetByUserIdAccountQuery : IRequest<GetByUserIdAccountResponse>, ISecuredRequest
    {
        public int UserId { get; set; }

        public string[] Roles => new[] { Admin, Read, GeneralOperationClaims.Instructor, GeneralOperationClaims.Student };

        public class GetByUserIdAccountQueryHandler : IRequestHandler<GetByUserIdAccountQuery, GetByUserIdAccountResponse>
        {
            private readonly IMapper _mapper;
            private readonly IAccountRepository _accountRepository;
            private readonly AccountBusinessRules _accountBusinessRules;

            public GetByUserIdAccountQueryHandler(IMapper mapper, IAccountRepository accountRepository, AccountBusinessRules accountBusinessRules)
            {
                _mapper = mapper;
                _accountRepository = accountRepository;
                _accountBusinessRules = accountBusinessRules;
            }

            public async Task<GetByUserIdAccountResponse> Handle(GetByUserIdAccountQuery request, CancellationToken cancellationToken)
            {
                Account? account = await _accountRepository.GetAsync(predicate: a => a.UserId == request.UserId, cancellationToken: cancellationToken);
                await _accountBusinessRules.AccountShouldExistWhenSelected(account);

                GetByUserIdAccountResponse response = _mapper.Map<GetByUserIdAccountResponse>(account);
                return response;
            }
        }
    }
}


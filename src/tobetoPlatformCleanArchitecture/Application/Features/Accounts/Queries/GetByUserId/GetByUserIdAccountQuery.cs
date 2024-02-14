using Application.Features.Accounts.Rules;
using Application.Features.OperationClaims.Constants;
using Application.Services.Repositories;
using Application.Services.UsersService;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using Domain.Entities;
using MediatR;
using System;

using static Application.Features.Accounts.Constants.AccountsOperationClaims;

namespace Application.Features.Accounts.Queries.GetByUserId
{
    public class GetByUserIdAccountQuery : IRequest<GetByUserIdAccountResponse>
    {
        public int? Id { get; set; }
        public int UserId { get; set; }

        public class GetByUserIdAccountQueryHandler : IRequestHandler<GetByUserIdAccountQuery, GetByUserIdAccountResponse>
        {
            private readonly IMapper _mapper;
            private readonly IAccountRepository _accountRepository;
            private readonly AccountBusinessRules _accountBusinessRules;

            private readonly IUserService _userService;

            public GetByUserIdAccountQueryHandler(IMapper mapper, IAccountRepository accountRepository, AccountBusinessRules accountBusinessRules, IUserService userService)
            {
                _mapper = mapper;
                _accountRepository = accountRepository;
                _accountBusinessRules = accountBusinessRules;
                _userService = userService;
            }

            public async Task<GetByUserIdAccountResponse> Handle(GetByUserIdAccountQuery request, CancellationToken cancellationToken)
            {
                Account? account = await _accountRepository.GetAsync(predicate: a => a.UserId == request.UserId, cancellationToken: cancellationToken);
                await _accountBusinessRules.AccountShouldExistWhenSelected(account);

                User? user = await _userService.GetAsync(predicate: u => u.Id == request.UserId, cancellationToken: cancellationToken);

                GetByUserIdAccountResponse response = _mapper.Map<GetByUserIdAccountResponse>(user);
                _mapper.Map(account, response);

                return response;
            }
        }
    }
}


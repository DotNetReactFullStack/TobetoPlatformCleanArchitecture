using Application.Features.Accounts.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.Accounts.Constants.AccountsOperationClaims;

namespace Application.Features.Accounts.Queries.GetList;

public class GetListAccountQuery : IRequest<GetListResponse<GetListAccountListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListAccounts({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetAccounts";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListAccountQueryHandler : IRequestHandler<GetListAccountQuery, GetListResponse<GetListAccountListItemDto>>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public GetListAccountQueryHandler(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListAccountListItemDto>> Handle(GetListAccountQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Account> accounts = await _accountRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListAccountListItemDto> response = _mapper.Map<GetListResponse<GetListAccountListItemDto>>(accounts);
            return response;
        }
    }
}
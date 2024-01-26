using Application.Features.AccountContracts.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.AccountContracts.Constants.AccountContractsOperationClaims;

namespace Application.Features.AccountContracts.Queries.GetList;

public class GetListAccountContractQuery : IRequest<GetListResponse<GetListAccountContractListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListAccountContracts({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetAccountContracts";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListAccountContractQueryHandler : IRequestHandler<GetListAccountContractQuery, GetListResponse<GetListAccountContractListItemDto>>
    {
        private readonly IAccountContractRepository _accountContractRepository;
        private readonly IMapper _mapper;

        public GetListAccountContractQueryHandler(IAccountContractRepository accountContractRepository, IMapper mapper)
        {
            _accountContractRepository = accountContractRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListAccountContractListItemDto>> Handle(GetListAccountContractQuery request, CancellationToken cancellationToken)
        {
            IPaginate<AccountContract> accountContracts = await _accountContractRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListAccountContractListItemDto> response = _mapper.Map<GetListResponse<GetListAccountContractListItemDto>>(accountContracts);
            return response;
        }
    }
}
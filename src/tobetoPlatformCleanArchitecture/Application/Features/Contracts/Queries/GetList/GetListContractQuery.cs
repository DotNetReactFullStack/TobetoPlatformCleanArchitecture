using Application.Features.Contracts.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.Contracts.Constants.ContractsOperationClaims;

namespace Application.Features.Contracts.Queries.GetList;

public class GetListContractQuery : IRequest<GetListResponse<GetListContractListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListContracts({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetContracts";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListContractQueryHandler : IRequestHandler<GetListContractQuery, GetListResponse<GetListContractListItemDto>>
    {
        private readonly IContractRepository _contractRepository;
        private readonly IMapper _mapper;

        public GetListContractQueryHandler(IContractRepository contractRepository, IMapper mapper)
        {
            _contractRepository = contractRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListContractListItemDto>> Handle(GetListContractQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Contract> contracts = await _contractRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListContractListItemDto> response = _mapper.Map<GetListResponse<GetListContractListItemDto>>(contracts);
            return response;
        }
    }
}
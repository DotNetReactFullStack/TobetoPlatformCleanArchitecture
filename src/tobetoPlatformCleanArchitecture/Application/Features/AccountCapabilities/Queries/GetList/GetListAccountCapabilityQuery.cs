using Application.Features.AccountCapabilities.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.AccountCapabilities.Constants.AccountCapabilitiesOperationClaims;

namespace Application.Features.AccountCapabilities.Queries.GetList;

public class GetListAccountCapabilityQuery : IRequest<GetListResponse<GetListAccountCapabilityListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListAccountCapabilities({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetAccountCapabilities";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListAccountCapabilityQueryHandler : IRequestHandler<GetListAccountCapabilityQuery, GetListResponse<GetListAccountCapabilityListItemDto>>
    {
        private readonly IAccountCapabilityRepository _accountCapabilityRepository;
        private readonly IMapper _mapper;

        public GetListAccountCapabilityQueryHandler(IAccountCapabilityRepository accountCapabilityRepository, IMapper mapper)
        {
            _accountCapabilityRepository = accountCapabilityRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListAccountCapabilityListItemDto>> Handle(GetListAccountCapabilityQuery request, CancellationToken cancellationToken)
        {
            IPaginate<AccountCapability> accountCapabilities = await _accountCapabilityRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListAccountCapabilityListItemDto> response = _mapper.Map<GetListResponse<GetListAccountCapabilityListItemDto>>(accountCapabilities);
            return response;
        }
    }
}
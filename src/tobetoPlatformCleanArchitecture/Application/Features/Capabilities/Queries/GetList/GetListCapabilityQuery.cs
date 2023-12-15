using Application.Features.Capabilities.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.Capabilities.Constants.CapabilitiesOperationClaims;

namespace Application.Features.Capabilities.Queries.GetList;

public class GetListCapabilityQuery : IRequest<GetListResponse<GetListCapabilityListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListCapabilities({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetCapabilities";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListCapabilityQueryHandler : IRequestHandler<GetListCapabilityQuery, GetListResponse<GetListCapabilityListItemDto>>
    {
        private readonly ICapabilityRepository _capabilityRepository;
        private readonly IMapper _mapper;

        public GetListCapabilityQueryHandler(ICapabilityRepository capabilityRepository, IMapper mapper)
        {
            _capabilityRepository = capabilityRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCapabilityListItemDto>> Handle(GetListCapabilityQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Capability> capabilities = await _capabilityRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCapabilityListItemDto> response = _mapper.Map<GetListResponse<GetListCapabilityListItemDto>>(capabilities);
            return response;
        }
    }
}
using Application.Features.Organizations.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.Organizations.Constants.OrganizationsOperationClaims;

namespace Application.Features.Organizations.Queries.GetList;

public class GetListOrganizationQuery : IRequest<GetListResponse<GetListOrganizationListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListOrganizations({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetOrganizations";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListOrganizationQueryHandler : IRequestHandler<GetListOrganizationQuery, GetListResponse<GetListOrganizationListItemDto>>
    {
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IMapper _mapper;

        public GetListOrganizationQueryHandler(IOrganizationRepository organizationRepository, IMapper mapper)
        {
            _organizationRepository = organizationRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListOrganizationListItemDto>> Handle(GetListOrganizationQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Organization> organizations = await _organizationRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListOrganizationListItemDto> response = _mapper.Map<GetListResponse<GetListOrganizationListItemDto>>(organizations);
            return response;
        }
    }
}
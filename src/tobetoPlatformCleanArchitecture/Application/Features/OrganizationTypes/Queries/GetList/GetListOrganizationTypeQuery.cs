using Application.Features.OrganizationTypes.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.OrganizationTypes.Constants.OrganizationTypesOperationClaims;

namespace Application.Features.OrganizationTypes.Queries.GetList;

public class GetListOrganizationTypeQuery : IRequest<GetListResponse<GetListOrganizationTypeListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListOrganizationTypes({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetOrganizationTypes";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListOrganizationTypeQueryHandler : IRequestHandler<GetListOrganizationTypeQuery, GetListResponse<GetListOrganizationTypeListItemDto>>
    {
        private readonly IOrganizationTypeRepository _organizationTypeRepository;
        private readonly IMapper _mapper;

        public GetListOrganizationTypeQueryHandler(IOrganizationTypeRepository organizationTypeRepository, IMapper mapper)
        {
            _organizationTypeRepository = organizationTypeRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListOrganizationTypeListItemDto>> Handle(GetListOrganizationTypeQuery request, CancellationToken cancellationToken)
        {
            IPaginate<OrganizationType> organizationTypes = await _organizationTypeRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListOrganizationTypeListItemDto> response = _mapper.Map<GetListResponse<GetListOrganizationTypeListItemDto>>(organizationTypes);
            return response;
        }
    }
}
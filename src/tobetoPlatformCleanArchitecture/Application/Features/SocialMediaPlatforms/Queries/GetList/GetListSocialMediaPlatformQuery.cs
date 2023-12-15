using Application.Features.SocialMediaPlatforms.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.SocialMediaPlatforms.Constants.SocialMediaPlatformsOperationClaims;

namespace Application.Features.SocialMediaPlatforms.Queries.GetList;

public class GetListSocialMediaPlatformQuery : IRequest<GetListResponse<GetListSocialMediaPlatformListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListSocialMediaPlatforms({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetSocialMediaPlatforms";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListSocialMediaPlatformQueryHandler : IRequestHandler<GetListSocialMediaPlatformQuery, GetListResponse<GetListSocialMediaPlatformListItemDto>>
    {
        private readonly ISocialMediaPlatformRepository _socialMediaPlatformRepository;
        private readonly IMapper _mapper;

        public GetListSocialMediaPlatformQueryHandler(ISocialMediaPlatformRepository socialMediaPlatformRepository, IMapper mapper)
        {
            _socialMediaPlatformRepository = socialMediaPlatformRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListSocialMediaPlatformListItemDto>> Handle(GetListSocialMediaPlatformQuery request, CancellationToken cancellationToken)
        {
            IPaginate<SocialMediaPlatform> socialMediaPlatforms = await _socialMediaPlatformRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListSocialMediaPlatformListItemDto> response = _mapper.Map<GetListResponse<GetListSocialMediaPlatformListItemDto>>(socialMediaPlatforms);
            return response;
        }
    }
}
using Application.Features.AccountSocialMediaPlatforms.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.AccountSocialMediaPlatforms.Constants.AccountSocialMediaPlatformsOperationClaims;

namespace Application.Features.AccountSocialMediaPlatforms.Queries.GetList;

public class GetListAccountSocialMediaPlatformQuery : IRequest<GetListResponse<GetListAccountSocialMediaPlatformListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListAccountSocialMediaPlatforms({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetAccountSocialMediaPlatforms";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListAccountSocialMediaPlatformQueryHandler : IRequestHandler<GetListAccountSocialMediaPlatformQuery, GetListResponse<GetListAccountSocialMediaPlatformListItemDto>>
    {
        private readonly IAccountSocialMediaPlatformRepository _accountSocialMediaPlatformRepository;
        private readonly IMapper _mapper;

        public GetListAccountSocialMediaPlatformQueryHandler(IAccountSocialMediaPlatformRepository accountSocialMediaPlatformRepository, IMapper mapper)
        {
            _accountSocialMediaPlatformRepository = accountSocialMediaPlatformRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListAccountSocialMediaPlatformListItemDto>> Handle(GetListAccountSocialMediaPlatformQuery request, CancellationToken cancellationToken)
        {
            IPaginate<AccountSocialMediaPlatform> accountSocialMediaPlatforms = await _accountSocialMediaPlatformRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListAccountSocialMediaPlatformListItemDto> response = _mapper.Map<GetListResponse<GetListAccountSocialMediaPlatformListItemDto>>(accountSocialMediaPlatforms);
            return response;
        }
    }
}
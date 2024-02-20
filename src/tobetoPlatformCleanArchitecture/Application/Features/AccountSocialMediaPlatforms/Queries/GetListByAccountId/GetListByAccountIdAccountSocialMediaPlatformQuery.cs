using Application.Features.AccountForeignLanguageMetadatas.Queries.GetListByAccountId;
using Application.Features.OperationClaims.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.Features.AccountSocialMediaPlatforms.Constants.AccountSocialMediaPlatformsOperationClaims;

namespace Application.Features.AccountSocialMediaPlatforms.Queries.GetListByAccountId;
public class GetListByAccountIdAccountSocialMediaPlatformQuery : IRequest<GetListResponse<GetListByAccountIdAccountSocialMediaPlatformListItemDto>>//, ISecuredRequest, ICachableRequest
{
    public int? Id { get; set; }
    public int AccountId { get; set; }
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read, GeneralOperationClaims.Instructor, GeneralOperationClaims.Student };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListByAccountId{AccountId}AccountSocialMediaPlatforms({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetAccountSocialMediaPlatforms";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListByAccountIdAccountSocialMediaPlatformsQueryHandler : IRequestHandler<GetListByAccountIdAccountSocialMediaPlatformQuery, GetListResponse<GetListByAccountIdAccountSocialMediaPlatformListItemDto>>
    {
        private readonly IAccountSocialMediaPlatformRepository _accountSocialMediaPlatformRepository;
        private readonly IMapper _mapper;

        public GetListByAccountIdAccountSocialMediaPlatformsQueryHandler(IAccountSocialMediaPlatformRepository accountSocialMediaPlatformRepository, IMapper mapper)
        {
            _accountSocialMediaPlatformRepository = accountSocialMediaPlatformRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListByAccountIdAccountSocialMediaPlatformListItemDto>> Handle(GetListByAccountIdAccountSocialMediaPlatformQuery request, CancellationToken cancellationToken)
        {
            IPaginate<AccountSocialMediaPlatform> accountSocialMediaPlatforms = await _accountSocialMediaPlatformRepository.GetListAsync(
                predicate: (ac => ac.AccountId == request.AccountId),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken,
                include: sm => sm.Include(p => p.SocialMediaPlatform)
            );

            GetListResponse<GetListByAccountIdAccountSocialMediaPlatformListItemDto> response = _mapper.Map<GetListResponse<GetListByAccountIdAccountSocialMediaPlatformListItemDto>>(accountSocialMediaPlatforms);
            return response;
        }
    }

}

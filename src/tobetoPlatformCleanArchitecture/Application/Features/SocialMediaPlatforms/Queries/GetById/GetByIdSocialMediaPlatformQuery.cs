using Application.Features.SocialMediaPlatforms.Constants;
using Application.Features.SocialMediaPlatforms.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.SocialMediaPlatforms.Constants.SocialMediaPlatformsOperationClaims;

namespace Application.Features.SocialMediaPlatforms.Queries.GetById;

public class GetByIdSocialMediaPlatformQuery : IRequest<GetByIdSocialMediaPlatformResponse>
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdSocialMediaPlatformQueryHandler : IRequestHandler<GetByIdSocialMediaPlatformQuery, GetByIdSocialMediaPlatformResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISocialMediaPlatformRepository _socialMediaPlatformRepository;
        private readonly SocialMediaPlatformBusinessRules _socialMediaPlatformBusinessRules;

        public GetByIdSocialMediaPlatformQueryHandler(IMapper mapper, ISocialMediaPlatformRepository socialMediaPlatformRepository, SocialMediaPlatformBusinessRules socialMediaPlatformBusinessRules)
        {
            _mapper = mapper;
            _socialMediaPlatformRepository = socialMediaPlatformRepository;
            _socialMediaPlatformBusinessRules = socialMediaPlatformBusinessRules;
        }

        public async Task<GetByIdSocialMediaPlatformResponse> Handle(GetByIdSocialMediaPlatformQuery request, CancellationToken cancellationToken)
        {
            SocialMediaPlatform? socialMediaPlatform = await _socialMediaPlatformRepository.GetAsync(predicate: smp => smp.Id == request.Id, cancellationToken: cancellationToken);
            await _socialMediaPlatformBusinessRules.SocialMediaPlatformShouldExistWhenSelected(socialMediaPlatform);

            GetByIdSocialMediaPlatformResponse response = _mapper.Map<GetByIdSocialMediaPlatformResponse>(socialMediaPlatform);
            return response;
        }
    }
}
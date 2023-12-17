using Application.Features.SocialMediaPlatforms.Constants;
using Application.Features.SocialMediaPlatforms.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.SocialMediaPlatforms.Constants.SocialMediaPlatformsOperationClaims;

namespace Application.Features.SocialMediaPlatforms.Commands.Create;

public class CreateSocialMediaPlatformCommand : IRequest<CreatedSocialMediaPlatformResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string Name { get; set; }
    public string IconPath { get; set; }
    public int Priority { get; set; }
    public bool Visibility { get; set; }

    public string[] Roles => new[] { Admin, Write, SocialMediaPlatformsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetSocialMediaPlatforms";

    public class CreateSocialMediaPlatformCommandHandler : IRequestHandler<CreateSocialMediaPlatformCommand, CreatedSocialMediaPlatformResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISocialMediaPlatformRepository _socialMediaPlatformRepository;
        private readonly SocialMediaPlatformBusinessRules _socialMediaPlatformBusinessRules;

        public CreateSocialMediaPlatformCommandHandler(IMapper mapper, ISocialMediaPlatformRepository socialMediaPlatformRepository,
                                         SocialMediaPlatformBusinessRules socialMediaPlatformBusinessRules)
        {
            _mapper = mapper;
            _socialMediaPlatformRepository = socialMediaPlatformRepository;
            _socialMediaPlatformBusinessRules = socialMediaPlatformBusinessRules;
        }

        public async Task<CreatedSocialMediaPlatformResponse> Handle(CreateSocialMediaPlatformCommand request, CancellationToken cancellationToken)
        {
            SocialMediaPlatform socialMediaPlatform = _mapper.Map<SocialMediaPlatform>(request);

            await _socialMediaPlatformRepository.AddAsync(socialMediaPlatform);

            CreatedSocialMediaPlatformResponse response = _mapper.Map<CreatedSocialMediaPlatformResponse>(socialMediaPlatform);
            return response;
        }
    }
}
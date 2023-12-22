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

namespace Application.Features.SocialMediaPlatforms.Commands.Update;

public class UpdateSocialMediaPlatformCommand : IRequest<UpdatedSocialMediaPlatformResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string IconPath { get; set; }
    public int Priority { get; set; }
    public bool Visibility { get; set; }

    public string[] Roles => new[] { Admin, Write, SocialMediaPlatformsOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetSocialMediaPlatforms";

    public class UpdateSocialMediaPlatformCommandHandler : IRequestHandler<UpdateSocialMediaPlatformCommand, UpdatedSocialMediaPlatformResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISocialMediaPlatformRepository _socialMediaPlatformRepository;
        private readonly SocialMediaPlatformBusinessRules _socialMediaPlatformBusinessRules;

        public UpdateSocialMediaPlatformCommandHandler(IMapper mapper, ISocialMediaPlatformRepository socialMediaPlatformRepository,
                                         SocialMediaPlatformBusinessRules socialMediaPlatformBusinessRules)
        {
            _mapper = mapper;
            _socialMediaPlatformRepository = socialMediaPlatformRepository;
            _socialMediaPlatformBusinessRules = socialMediaPlatformBusinessRules;
        }

        public async Task<UpdatedSocialMediaPlatformResponse> Handle(UpdateSocialMediaPlatformCommand request, CancellationToken cancellationToken)
        {
            SocialMediaPlatform? socialMediaPlatform = await _socialMediaPlatformRepository.GetAsync(predicate: smp => smp.Id == request.Id, cancellationToken: cancellationToken);
            await _socialMediaPlatformBusinessRules.SocialMediaPlatformShouldExistWhenSelected(socialMediaPlatform);
            socialMediaPlatform = _mapper.Map(request, socialMediaPlatform);

            await _socialMediaPlatformRepository.UpdateAsync(socialMediaPlatform!);

            UpdatedSocialMediaPlatformResponse response = _mapper.Map<UpdatedSocialMediaPlatformResponse>(socialMediaPlatform);
            return response;
        }
    }
}
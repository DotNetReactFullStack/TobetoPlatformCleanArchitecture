using Application.Features.SocialMediaPlatforms.Constants;
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

namespace Application.Features.SocialMediaPlatforms.Commands.Delete;

public class DeleteSocialMediaPlatformCommand : IRequest<DeletedSocialMediaPlatformResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, SocialMediaPlatformsOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetSocialMediaPlatforms";

    public class DeleteSocialMediaPlatformCommandHandler : IRequestHandler<DeleteSocialMediaPlatformCommand, DeletedSocialMediaPlatformResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISocialMediaPlatformRepository _socialMediaPlatformRepository;
        private readonly SocialMediaPlatformBusinessRules _socialMediaPlatformBusinessRules;

        public DeleteSocialMediaPlatformCommandHandler(IMapper mapper, ISocialMediaPlatformRepository socialMediaPlatformRepository,
                                         SocialMediaPlatformBusinessRules socialMediaPlatformBusinessRules)
        {
            _mapper = mapper;
            _socialMediaPlatformRepository = socialMediaPlatformRepository;
            _socialMediaPlatformBusinessRules = socialMediaPlatformBusinessRules;
        }

        public async Task<DeletedSocialMediaPlatformResponse> Handle(DeleteSocialMediaPlatformCommand request, CancellationToken cancellationToken)
        {
            SocialMediaPlatform? socialMediaPlatform = await _socialMediaPlatformRepository.GetAsync(predicate: smp => smp.Id == request.Id, cancellationToken: cancellationToken);
            await _socialMediaPlatformBusinessRules.SocialMediaPlatformShouldExistWhenSelected(socialMediaPlatform);

            await _socialMediaPlatformRepository.DeleteAsync(socialMediaPlatform!);

            DeletedSocialMediaPlatformResponse response = _mapper.Map<DeletedSocialMediaPlatformResponse>(socialMediaPlatform);
            return response;
        }
    }
}
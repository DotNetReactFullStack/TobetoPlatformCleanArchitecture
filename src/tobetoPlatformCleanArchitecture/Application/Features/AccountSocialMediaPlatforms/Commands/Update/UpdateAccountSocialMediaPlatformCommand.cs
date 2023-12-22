using Application.Features.AccountSocialMediaPlatforms.Constants;
using Application.Features.AccountSocialMediaPlatforms.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.AccountSocialMediaPlatforms.Constants.AccountSocialMediaPlatformsOperationClaims;

namespace Application.Features.AccountSocialMediaPlatforms.Commands.Update;

public class UpdateAccountSocialMediaPlatformCommand : IRequest<UpdatedAccountSocialMediaPlatformResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public int SocialMediaPlatformId { get; set; }
    public int Priority { get; set; }
    public string Link { get; set; }

    public string[] Roles => new[] { Admin, Write, AccountSocialMediaPlatformsOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetAccountSocialMediaPlatforms";

    public class UpdateAccountSocialMediaPlatformCommandHandler : IRequestHandler<UpdateAccountSocialMediaPlatformCommand, UpdatedAccountSocialMediaPlatformResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountSocialMediaPlatformRepository _accountSocialMediaPlatformRepository;
        private readonly AccountSocialMediaPlatformBusinessRules _accountSocialMediaPlatformBusinessRules;

        public UpdateAccountSocialMediaPlatformCommandHandler(IMapper mapper, IAccountSocialMediaPlatformRepository accountSocialMediaPlatformRepository,
                                         AccountSocialMediaPlatformBusinessRules accountSocialMediaPlatformBusinessRules)
        {
            _mapper = mapper;
            _accountSocialMediaPlatformRepository = accountSocialMediaPlatformRepository;
            _accountSocialMediaPlatformBusinessRules = accountSocialMediaPlatformBusinessRules;
        }

        public async Task<UpdatedAccountSocialMediaPlatformResponse> Handle(UpdateAccountSocialMediaPlatformCommand request, CancellationToken cancellationToken)
        {
            AccountSocialMediaPlatform? accountSocialMediaPlatform = await _accountSocialMediaPlatformRepository.GetAsync(predicate: asmp => asmp.Id == request.Id, cancellationToken: cancellationToken);
            await _accountSocialMediaPlatformBusinessRules.AccountSocialMediaPlatformShouldExistWhenSelected(accountSocialMediaPlatform);
            accountSocialMediaPlatform = _mapper.Map(request, accountSocialMediaPlatform);

            await _accountSocialMediaPlatformRepository.UpdateAsync(accountSocialMediaPlatform!);

            UpdatedAccountSocialMediaPlatformResponse response = _mapper.Map<UpdatedAccountSocialMediaPlatformResponse>(accountSocialMediaPlatform);
            return response;
        }
    }
}
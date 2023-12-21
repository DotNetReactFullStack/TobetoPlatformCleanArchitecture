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

namespace Application.Features.AccountSocialMediaPlatforms.Commands.Create;

public class CreateAccountSocialMediaPlatformCommand : IRequest<CreatedAccountSocialMediaPlatformResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int AccountId { get; set; }
    public int SocialMediaPlatformId { get; set; }
    public int Priority { get; set; }
    public string Link { get; set; }

    public string[] Roles => new[] { Admin, Write, AccountSocialMediaPlatformsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetAccountSocialMediaPlatforms";

    public class CreateAccountSocialMediaPlatformCommandHandler : IRequestHandler<CreateAccountSocialMediaPlatformCommand, CreatedAccountSocialMediaPlatformResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountSocialMediaPlatformRepository _accountSocialMediaPlatformRepository;
        private readonly AccountSocialMediaPlatformBusinessRules _accountSocialMediaPlatformBusinessRules;

        public CreateAccountSocialMediaPlatformCommandHandler(IMapper mapper, IAccountSocialMediaPlatformRepository accountSocialMediaPlatformRepository,
                                         AccountSocialMediaPlatformBusinessRules accountSocialMediaPlatformBusinessRules)
        {
            _mapper = mapper;
            _accountSocialMediaPlatformRepository = accountSocialMediaPlatformRepository;
            _accountSocialMediaPlatformBusinessRules = accountSocialMediaPlatformBusinessRules;
        }

        public async Task<CreatedAccountSocialMediaPlatformResponse> Handle(CreateAccountSocialMediaPlatformCommand request, CancellationToken cancellationToken)
        {
            AccountSocialMediaPlatform accountSocialMediaPlatform = _mapper.Map<AccountSocialMediaPlatform>(request);

            _accountSocialMediaPlatformBusinessRules.AccountCanHasMaximumThreeSocialMediaPlatforms(accountSocialMediaPlatform);

            await _accountSocialMediaPlatformRepository.AddAsync(accountSocialMediaPlatform);

            CreatedAccountSocialMediaPlatformResponse response = _mapper.Map<CreatedAccountSocialMediaPlatformResponse>(accountSocialMediaPlatform);
            return response;
        }
    }
}
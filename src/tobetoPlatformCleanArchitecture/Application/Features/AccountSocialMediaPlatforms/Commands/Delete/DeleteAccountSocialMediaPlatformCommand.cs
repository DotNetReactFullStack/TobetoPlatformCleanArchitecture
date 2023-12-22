using Application.Features.AccountSocialMediaPlatforms.Constants;
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

namespace Application.Features.AccountSocialMediaPlatforms.Commands.Delete;

public class DeleteAccountSocialMediaPlatformCommand : IRequest<DeletedAccountSocialMediaPlatformResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, AccountSocialMediaPlatformsOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetAccountSocialMediaPlatforms";

    public class DeleteAccountSocialMediaPlatformCommandHandler : IRequestHandler<DeleteAccountSocialMediaPlatformCommand, DeletedAccountSocialMediaPlatformResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountSocialMediaPlatformRepository _accountSocialMediaPlatformRepository;
        private readonly AccountSocialMediaPlatformBusinessRules _accountSocialMediaPlatformBusinessRules;

        public DeleteAccountSocialMediaPlatformCommandHandler(IMapper mapper, IAccountSocialMediaPlatformRepository accountSocialMediaPlatformRepository,
                                         AccountSocialMediaPlatformBusinessRules accountSocialMediaPlatformBusinessRules)
        {
            _mapper = mapper;
            _accountSocialMediaPlatformRepository = accountSocialMediaPlatformRepository;
            _accountSocialMediaPlatformBusinessRules = accountSocialMediaPlatformBusinessRules;
        }

        public async Task<DeletedAccountSocialMediaPlatformResponse> Handle(DeleteAccountSocialMediaPlatformCommand request, CancellationToken cancellationToken)
        {
            AccountSocialMediaPlatform? accountSocialMediaPlatform = await _accountSocialMediaPlatformRepository.GetAsync(predicate: asmp => asmp.Id == request.Id, cancellationToken: cancellationToken);
            await _accountSocialMediaPlatformBusinessRules.AccountSocialMediaPlatformShouldExistWhenSelected(accountSocialMediaPlatform);

            await _accountSocialMediaPlatformRepository.DeleteAsync(accountSocialMediaPlatform!);

            DeletedAccountSocialMediaPlatformResponse response = _mapper.Map<DeletedAccountSocialMediaPlatformResponse>(accountSocialMediaPlatform);
            return response;
        }
    }
}
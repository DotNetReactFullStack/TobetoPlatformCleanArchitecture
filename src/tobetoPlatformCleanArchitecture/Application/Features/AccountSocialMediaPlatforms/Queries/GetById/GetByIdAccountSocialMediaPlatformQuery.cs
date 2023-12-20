using Application.Features.AccountSocialMediaPlatforms.Constants;
using Application.Features.AccountSocialMediaPlatforms.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.AccountSocialMediaPlatforms.Constants.AccountSocialMediaPlatformsOperationClaims;

namespace Application.Features.AccountSocialMediaPlatforms.Queries.GetById;

public class GetByIdAccountSocialMediaPlatformQuery : IRequest<GetByIdAccountSocialMediaPlatformResponse>
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdAccountSocialMediaPlatformQueryHandler : IRequestHandler<GetByIdAccountSocialMediaPlatformQuery, GetByIdAccountSocialMediaPlatformResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountSocialMediaPlatformRepository _accountSocialMediaPlatformRepository;
        private readonly AccountSocialMediaPlatformBusinessRules _accountSocialMediaPlatformBusinessRules;

        public GetByIdAccountSocialMediaPlatformQueryHandler(IMapper mapper, IAccountSocialMediaPlatformRepository accountSocialMediaPlatformRepository, AccountSocialMediaPlatformBusinessRules accountSocialMediaPlatformBusinessRules)
        {
            _mapper = mapper;
            _accountSocialMediaPlatformRepository = accountSocialMediaPlatformRepository;
            _accountSocialMediaPlatformBusinessRules = accountSocialMediaPlatformBusinessRules;
        }

        public async Task<GetByIdAccountSocialMediaPlatformResponse> Handle(GetByIdAccountSocialMediaPlatformQuery request, CancellationToken cancellationToken)
        {
            AccountSocialMediaPlatform? accountSocialMediaPlatform = await _accountSocialMediaPlatformRepository.GetAsync(predicate: asmp => asmp.Id == request.Id, cancellationToken: cancellationToken);
            await _accountSocialMediaPlatformBusinessRules.AccountSocialMediaPlatformShouldExistWhenSelected(accountSocialMediaPlatform);

            GetByIdAccountSocialMediaPlatformResponse response = _mapper.Map<GetByIdAccountSocialMediaPlatformResponse>(accountSocialMediaPlatform);
            return response;
        }
    }
}
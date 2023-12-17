using Application.Features.AccountCapabilities.Constants;
using Application.Features.AccountCapabilities.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.AccountCapabilities.Constants.AccountCapabilitiesOperationClaims;

namespace Application.Features.AccountCapabilities.Commands.Create;

public class CreateAccountCapabilityCommand : IRequest<CreatedAccountCapabilityResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int AccountId { get; set; }
    public int CapabilityId { get; set; }
    public int Priority { get; set; }

    public string[] Roles => new[] { Admin, Write, AccountCapabilitiesOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetAccountCapabilities";

    public class CreateAccountCapabilityCommandHandler : IRequestHandler<CreateAccountCapabilityCommand, CreatedAccountCapabilityResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountCapabilityRepository _accountCapabilityRepository;
        private readonly AccountCapabilityBusinessRules _accountCapabilityBusinessRules;

        public CreateAccountCapabilityCommandHandler(IMapper mapper, IAccountCapabilityRepository accountCapabilityRepository,
                                         AccountCapabilityBusinessRules accountCapabilityBusinessRules)
        {
            _mapper = mapper;
            _accountCapabilityRepository = accountCapabilityRepository;
            _accountCapabilityBusinessRules = accountCapabilityBusinessRules;
        }

        public async Task<CreatedAccountCapabilityResponse> Handle(CreateAccountCapabilityCommand request, CancellationToken cancellationToken)
        {
            AccountCapability accountCapability = _mapper.Map<AccountCapability>(request);

            await _accountCapabilityRepository.AddAsync(accountCapability);

            CreatedAccountCapabilityResponse response = _mapper.Map<CreatedAccountCapabilityResponse>(accountCapability);
            return response;
        }
    }
}
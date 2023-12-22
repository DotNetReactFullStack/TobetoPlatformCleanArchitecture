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

namespace Application.Features.AccountCapabilities.Commands.Update;

public class UpdateAccountCapabilityCommand : IRequest<UpdatedAccountCapabilityResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public int CapabilityId { get; set; }
    public int Priority { get; set; }

    public string[] Roles => new[] { Admin, Write, AccountCapabilitiesOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetAccountCapabilities";

    public class UpdateAccountCapabilityCommandHandler : IRequestHandler<UpdateAccountCapabilityCommand, UpdatedAccountCapabilityResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountCapabilityRepository _accountCapabilityRepository;
        private readonly AccountCapabilityBusinessRules _accountCapabilityBusinessRules;

        public UpdateAccountCapabilityCommandHandler(IMapper mapper, IAccountCapabilityRepository accountCapabilityRepository,
                                         AccountCapabilityBusinessRules accountCapabilityBusinessRules)
        {
            _mapper = mapper;
            _accountCapabilityRepository = accountCapabilityRepository;
            _accountCapabilityBusinessRules = accountCapabilityBusinessRules;
        }

        public async Task<UpdatedAccountCapabilityResponse> Handle(UpdateAccountCapabilityCommand request, CancellationToken cancellationToken)
        {
            AccountCapability? accountCapability = await _accountCapabilityRepository.GetAsync(predicate: ac => ac.Id == request.Id, cancellationToken: cancellationToken);
            await _accountCapabilityBusinessRules.AccountCapabilityShouldExistWhenSelected(accountCapability);
            accountCapability = _mapper.Map(request, accountCapability);

            await _accountCapabilityRepository.UpdateAsync(accountCapability!);

            UpdatedAccountCapabilityResponse response = _mapper.Map<UpdatedAccountCapabilityResponse>(accountCapability);
            return response;
        }
    }
}
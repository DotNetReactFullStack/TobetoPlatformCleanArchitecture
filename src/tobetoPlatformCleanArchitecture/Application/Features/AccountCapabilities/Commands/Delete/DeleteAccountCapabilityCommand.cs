using Application.Features.AccountCapabilities.Constants;
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

namespace Application.Features.AccountCapabilities.Commands.Delete;

public class DeleteAccountCapabilityCommand : IRequest<DeletedAccountCapabilityResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, AccountCapabilitiesOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetAccountCapabilities";

    public class DeleteAccountCapabilityCommandHandler : IRequestHandler<DeleteAccountCapabilityCommand, DeletedAccountCapabilityResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountCapabilityRepository _accountCapabilityRepository;
        private readonly AccountCapabilityBusinessRules _accountCapabilityBusinessRules;

        public DeleteAccountCapabilityCommandHandler(IMapper mapper, IAccountCapabilityRepository accountCapabilityRepository,
                                         AccountCapabilityBusinessRules accountCapabilityBusinessRules)
        {
            _mapper = mapper;
            _accountCapabilityRepository = accountCapabilityRepository;
            _accountCapabilityBusinessRules = accountCapabilityBusinessRules;
        }

        public async Task<DeletedAccountCapabilityResponse> Handle(DeleteAccountCapabilityCommand request, CancellationToken cancellationToken)
        {
            AccountCapability? accountCapability = await _accountCapabilityRepository.GetAsync(predicate: ac => ac.Id == request.Id, cancellationToken: cancellationToken);
            await _accountCapabilityBusinessRules.AccountCapabilityShouldExistWhenSelected(accountCapability);

            await _accountCapabilityRepository.DeleteAsync(accountCapability!);

            DeletedAccountCapabilityResponse response = _mapper.Map<DeletedAccountCapabilityResponse>(accountCapability);
            return response;
        }
    }
}
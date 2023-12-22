using Application.Features.Capabilities.Constants;
using Application.Features.Capabilities.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Capabilities.Constants.CapabilitiesOperationClaims;

namespace Application.Features.Capabilities.Commands.Update;

public class UpdateCapabilityCommand : IRequest<UpdatedCapabilityResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Priority { get; set; }
    public bool Visibility { get; set; }

    public string[] Roles => new[] { Admin, Write, CapabilitiesOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetCapabilities";

    public class UpdateCapabilityCommandHandler : IRequestHandler<UpdateCapabilityCommand, UpdatedCapabilityResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICapabilityRepository _capabilityRepository;
        private readonly CapabilityBusinessRules _capabilityBusinessRules;

        public UpdateCapabilityCommandHandler(IMapper mapper, ICapabilityRepository capabilityRepository,
                                         CapabilityBusinessRules capabilityBusinessRules)
        {
            _mapper = mapper;
            _capabilityRepository = capabilityRepository;
            _capabilityBusinessRules = capabilityBusinessRules;
        }

        public async Task<UpdatedCapabilityResponse> Handle(UpdateCapabilityCommand request, CancellationToken cancellationToken)
        {
            Capability? capability = await _capabilityRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _capabilityBusinessRules.CapabilityShouldExistWhenSelected(capability);
            capability = _mapper.Map(request, capability);

            await _capabilityRepository.UpdateAsync(capability!);

            UpdatedCapabilityResponse response = _mapper.Map<UpdatedCapabilityResponse>(capability);
            return response;
        }
    }
}
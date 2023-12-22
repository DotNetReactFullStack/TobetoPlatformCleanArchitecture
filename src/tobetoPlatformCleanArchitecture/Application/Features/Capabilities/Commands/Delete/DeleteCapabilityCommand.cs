using Application.Features.Capabilities.Constants;
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

namespace Application.Features.Capabilities.Commands.Delete;

public class DeleteCapabilityCommand : IRequest<DeletedCapabilityResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, CapabilitiesOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetCapabilities";

    public class DeleteCapabilityCommandHandler : IRequestHandler<DeleteCapabilityCommand, DeletedCapabilityResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICapabilityRepository _capabilityRepository;
        private readonly CapabilityBusinessRules _capabilityBusinessRules;

        public DeleteCapabilityCommandHandler(IMapper mapper, ICapabilityRepository capabilityRepository,
                                         CapabilityBusinessRules capabilityBusinessRules)
        {
            _mapper = mapper;
            _capabilityRepository = capabilityRepository;
            _capabilityBusinessRules = capabilityBusinessRules;
        }

        public async Task<DeletedCapabilityResponse> Handle(DeleteCapabilityCommand request, CancellationToken cancellationToken)
        {
            Capability? capability = await _capabilityRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _capabilityBusinessRules.CapabilityShouldExistWhenSelected(capability);

            await _capabilityRepository.DeleteAsync(capability!);

            DeletedCapabilityResponse response = _mapper.Map<DeletedCapabilityResponse>(capability);
            return response;
        }
    }
}
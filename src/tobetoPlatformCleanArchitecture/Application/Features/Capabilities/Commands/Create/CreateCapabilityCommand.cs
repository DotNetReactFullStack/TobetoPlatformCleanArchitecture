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

namespace Application.Features.Capabilities.Commands.Create;

public class CreateCapabilityCommand : IRequest<CreatedCapabilityResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string Name { get; set; }
    public int Priority { get; set; }
    public bool Visibility { get; set; }

    public string[] Roles => new[] { Admin, Write, CapabilitiesOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetCapabilities";

    public class CreateCapabilityCommandHandler : IRequestHandler<CreateCapabilityCommand, CreatedCapabilityResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICapabilityRepository _capabilityRepository;
        private readonly CapabilityBusinessRules _capabilityBusinessRules;

        public CreateCapabilityCommandHandler(IMapper mapper, ICapabilityRepository capabilityRepository,
                                         CapabilityBusinessRules capabilityBusinessRules)
        {
            _mapper = mapper;
            _capabilityRepository = capabilityRepository;
            _capabilityBusinessRules = capabilityBusinessRules;
        }

        public async Task<CreatedCapabilityResponse> Handle(CreateCapabilityCommand request, CancellationToken cancellationToken)
        {
            Capability capability = _mapper.Map<Capability>(request);

            await _capabilityRepository.AddAsync(capability);

            CreatedCapabilityResponse response = _mapper.Map<CreatedCapabilityResponse>(capability);
            return response;
        }
    }
}
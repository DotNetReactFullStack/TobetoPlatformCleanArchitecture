using Application.Features.Capabilities.Constants;
using Application.Features.Capabilities.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Capabilities.Constants.CapabilitiesOperationClaims;

namespace Application.Features.Capabilities.Queries.GetById;

public class GetByIdCapabilityQuery : IRequest<GetByIdCapabilityResponse>
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdCapabilityQueryHandler : IRequestHandler<GetByIdCapabilityQuery, GetByIdCapabilityResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICapabilityRepository _capabilityRepository;
        private readonly CapabilityBusinessRules _capabilityBusinessRules;

        public GetByIdCapabilityQueryHandler(IMapper mapper, ICapabilityRepository capabilityRepository, CapabilityBusinessRules capabilityBusinessRules)
        {
            _mapper = mapper;
            _capabilityRepository = capabilityRepository;
            _capabilityBusinessRules = capabilityBusinessRules;
        }

        public async Task<GetByIdCapabilityResponse> Handle(GetByIdCapabilityQuery request, CancellationToken cancellationToken)
        {
            Capability? capability = await _capabilityRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _capabilityBusinessRules.CapabilityShouldExistWhenSelected(capability);

            GetByIdCapabilityResponse response = _mapper.Map<GetByIdCapabilityResponse>(capability);
            return response;
        }
    }
}
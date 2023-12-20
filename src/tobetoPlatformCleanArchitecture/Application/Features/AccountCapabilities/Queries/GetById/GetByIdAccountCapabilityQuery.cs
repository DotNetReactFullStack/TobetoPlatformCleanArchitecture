using Application.Features.AccountCapabilities.Constants;
using Application.Features.AccountCapabilities.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.AccountCapabilities.Constants.AccountCapabilitiesOperationClaims;

namespace Application.Features.AccountCapabilities.Queries.GetById;

public class GetByIdAccountCapabilityQuery : IRequest<GetByIdAccountCapabilityResponse>
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdAccountCapabilityQueryHandler : IRequestHandler<GetByIdAccountCapabilityQuery, GetByIdAccountCapabilityResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountCapabilityRepository _accountCapabilityRepository;
        private readonly AccountCapabilityBusinessRules _accountCapabilityBusinessRules;

        public GetByIdAccountCapabilityQueryHandler(IMapper mapper, IAccountCapabilityRepository accountCapabilityRepository, AccountCapabilityBusinessRules accountCapabilityBusinessRules)
        {
            _mapper = mapper;
            _accountCapabilityRepository = accountCapabilityRepository;
            _accountCapabilityBusinessRules = accountCapabilityBusinessRules;
        }

        public async Task<GetByIdAccountCapabilityResponse> Handle(GetByIdAccountCapabilityQuery request, CancellationToken cancellationToken)
        {
            AccountCapability? accountCapability = await _accountCapabilityRepository.GetAsync(predicate: ac => ac.Id == request.Id, cancellationToken: cancellationToken);
            await _accountCapabilityBusinessRules.AccountCapabilityShouldExistWhenSelected(accountCapability);

            GetByIdAccountCapabilityResponse response = _mapper.Map<GetByIdAccountCapabilityResponse>(accountCapability);
            return response;
        }
    }
}
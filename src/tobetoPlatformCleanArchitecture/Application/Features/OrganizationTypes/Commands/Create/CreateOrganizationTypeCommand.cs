using Application.Features.OrganizationTypes.Constants;
using Application.Features.OrganizationTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.OrganizationTypes.Constants.OrganizationTypesOperationClaims;

namespace Application.Features.OrganizationTypes.Commands.Create;

public class CreateOrganizationTypeCommand : IRequest<CreatedOrganizationTypeResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string Name { get; set; }
    public int Priority { get; set; }
    public bool Visibility { get; set; }

    public string[] Roles => new[] { Admin, Write, OrganizationTypesOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetOrganizationTypes";

    public class CreateOrganizationTypeCommandHandler : IRequestHandler<CreateOrganizationTypeCommand, CreatedOrganizationTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOrganizationTypeRepository _organizationTypeRepository;
        private readonly OrganizationTypeBusinessRules _organizationTypeBusinessRules;

        public CreateOrganizationTypeCommandHandler(IMapper mapper, IOrganizationTypeRepository organizationTypeRepository,
                                         OrganizationTypeBusinessRules organizationTypeBusinessRules)
        {
            _mapper = mapper;
            _organizationTypeRepository = organizationTypeRepository;
            _organizationTypeBusinessRules = organizationTypeBusinessRules;
        }

        public async Task<CreatedOrganizationTypeResponse> Handle(CreateOrganizationTypeCommand request, CancellationToken cancellationToken)
        {
            OrganizationType organizationType = _mapper.Map<OrganizationType>(request);

            await _organizationTypeRepository.AddAsync(organizationType);

            CreatedOrganizationTypeResponse response = _mapper.Map<CreatedOrganizationTypeResponse>(organizationType);
            return response;
        }
    }
}
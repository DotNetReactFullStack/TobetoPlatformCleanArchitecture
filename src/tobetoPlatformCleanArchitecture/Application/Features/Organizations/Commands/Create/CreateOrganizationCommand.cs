using Application.Features.Organizations.Constants;
using Application.Features.Organizations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Organizations.Constants.OrganizationsOperationClaims;

namespace Application.Features.Organizations.Commands.Create;

public class CreateOrganizationCommand : IRequest<CreatedOrganizationResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int OrganizationTypeId { get; set; }
    public int AddressId { get; set; }
    public bool Visibility { get; set; }
    public string Name { get; set; }
    public string ContactNumber { get; set; }

    public string[] Roles => new[] { Admin, Write, OrganizationsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetOrganizations";

    public class CreateOrganizationCommandHandler : IRequestHandler<CreateOrganizationCommand, CreatedOrganizationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly OrganizationBusinessRules _organizationBusinessRules;

        public CreateOrganizationCommandHandler(IMapper mapper, IOrganizationRepository organizationRepository,
                                         OrganizationBusinessRules organizationBusinessRules)
        {
            _mapper = mapper;
            _organizationRepository = organizationRepository;
            _organizationBusinessRules = organizationBusinessRules;
        }

        public async Task<CreatedOrganizationResponse> Handle(CreateOrganizationCommand request, CancellationToken cancellationToken)
        {
            Organization organization = _mapper.Map<Organization>(request);

            await _organizationRepository.AddAsync(organization);

            CreatedOrganizationResponse response = _mapper.Map<CreatedOrganizationResponse>(organization);
            return response;
        }
    }
}
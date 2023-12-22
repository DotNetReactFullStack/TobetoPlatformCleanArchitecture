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

namespace Application.Features.Organizations.Commands.Update;

public class UpdateOrganizationCommand : IRequest<UpdatedOrganizationResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public int OrganizationTypeId { get; set; }
    public int AddressId { get; set; }
    public bool Visibility { get; set; }
    public string Name { get; set; }
    public string ContactNumber { get; set; }

    public string[] Roles => new[] { Admin, Write, OrganizationsOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetOrganizations";

    public class UpdateOrganizationCommandHandler : IRequestHandler<UpdateOrganizationCommand, UpdatedOrganizationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly OrganizationBusinessRules _organizationBusinessRules;

        public UpdateOrganizationCommandHandler(IMapper mapper, IOrganizationRepository organizationRepository,
                                         OrganizationBusinessRules organizationBusinessRules)
        {
            _mapper = mapper;
            _organizationRepository = organizationRepository;
            _organizationBusinessRules = organizationBusinessRules;
        }

        public async Task<UpdatedOrganizationResponse> Handle(UpdateOrganizationCommand request, CancellationToken cancellationToken)
        {
            Organization? organization = await _organizationRepository.GetAsync(predicate: o => o.Id == request.Id, cancellationToken: cancellationToken);
            await _organizationBusinessRules.OrganizationShouldExistWhenSelected(organization);
            organization = _mapper.Map(request, organization);

            await _organizationRepository.UpdateAsync(organization!);

            UpdatedOrganizationResponse response = _mapper.Map<UpdatedOrganizationResponse>(organization);
            return response;
        }
    }
}
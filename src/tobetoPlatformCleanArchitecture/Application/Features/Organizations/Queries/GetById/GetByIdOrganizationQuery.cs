using Application.Features.Organizations.Constants;
using Application.Features.Organizations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Organizations.Constants.OrganizationsOperationClaims;

namespace Application.Features.Organizations.Queries.GetById;

public class GetByIdOrganizationQuery : IRequest<GetByIdOrganizationResponse>
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdOrganizationQueryHandler : IRequestHandler<GetByIdOrganizationQuery, GetByIdOrganizationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly OrganizationBusinessRules _organizationBusinessRules;

        public GetByIdOrganizationQueryHandler(IMapper mapper, IOrganizationRepository organizationRepository, OrganizationBusinessRules organizationBusinessRules)
        {
            _mapper = mapper;
            _organizationRepository = organizationRepository;
            _organizationBusinessRules = organizationBusinessRules;
        }

        public async Task<GetByIdOrganizationResponse> Handle(GetByIdOrganizationQuery request, CancellationToken cancellationToken)
        {
            Organization? organization = await _organizationRepository.GetAsync(predicate: o => o.Id == request.Id, cancellationToken: cancellationToken);
            await _organizationBusinessRules.OrganizationShouldExistWhenSelected(organization);

            GetByIdOrganizationResponse response = _mapper.Map<GetByIdOrganizationResponse>(organization);
            return response;
        }
    }
}
using Application.Features.OrganizationTypes.Constants;
using Application.Features.OrganizationTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.OrganizationTypes.Constants.OrganizationTypesOperationClaims;

namespace Application.Features.OrganizationTypes.Queries.GetById;

public class GetByIdOrganizationTypeQuery : IRequest<GetByIdOrganizationTypeResponse>
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdOrganizationTypeQueryHandler : IRequestHandler<GetByIdOrganizationTypeQuery, GetByIdOrganizationTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOrganizationTypeRepository _organizationTypeRepository;
        private readonly OrganizationTypeBusinessRules _organizationTypeBusinessRules;

        public GetByIdOrganizationTypeQueryHandler(IMapper mapper, IOrganizationTypeRepository organizationTypeRepository, OrganizationTypeBusinessRules organizationTypeBusinessRules)
        {
            _mapper = mapper;
            _organizationTypeRepository = organizationTypeRepository;
            _organizationTypeBusinessRules = organizationTypeBusinessRules;
        }

        public async Task<GetByIdOrganizationTypeResponse> Handle(GetByIdOrganizationTypeQuery request, CancellationToken cancellationToken)
        {
            OrganizationType? organizationType = await _organizationTypeRepository.GetAsync(predicate: ot => ot.Id == request.Id, cancellationToken: cancellationToken);
            await _organizationTypeBusinessRules.OrganizationTypeShouldExistWhenSelected(organizationType);

            GetByIdOrganizationTypeResponse response = _mapper.Map<GetByIdOrganizationTypeResponse>(organizationType);
            return response;
        }
    }
}
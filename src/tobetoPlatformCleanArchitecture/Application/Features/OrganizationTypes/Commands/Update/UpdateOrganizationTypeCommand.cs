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

namespace Application.Features.OrganizationTypes.Commands.Update;

public class UpdateOrganizationTypeCommand : IRequest<UpdatedOrganizationTypeResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Priority { get; set; }
    public bool Visibility { get; set; }

    public string[] Roles => new[] { Admin, Write, OrganizationTypesOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetOrganizationTypes";

    public class UpdateOrganizationTypeCommandHandler : IRequestHandler<UpdateOrganizationTypeCommand, UpdatedOrganizationTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOrganizationTypeRepository _organizationTypeRepository;
        private readonly OrganizationTypeBusinessRules _organizationTypeBusinessRules;

        public UpdateOrganizationTypeCommandHandler(IMapper mapper, IOrganizationTypeRepository organizationTypeRepository,
                                         OrganizationTypeBusinessRules organizationTypeBusinessRules)
        {
            _mapper = mapper;
            _organizationTypeRepository = organizationTypeRepository;
            _organizationTypeBusinessRules = organizationTypeBusinessRules;
        }

        public async Task<UpdatedOrganizationTypeResponse> Handle(UpdateOrganizationTypeCommand request, CancellationToken cancellationToken)
        {
            OrganizationType? organizationType = await _organizationTypeRepository.GetAsync(predicate: ot => ot.Id == request.Id, cancellationToken: cancellationToken);
            await _organizationTypeBusinessRules.OrganizationTypeShouldExistWhenSelected(organizationType);
            organizationType = _mapper.Map(request, organizationType);

            await _organizationTypeRepository.UpdateAsync(organizationType!);

            UpdatedOrganizationTypeResponse response = _mapper.Map<UpdatedOrganizationTypeResponse>(organizationType);
            return response;
        }
    }
}
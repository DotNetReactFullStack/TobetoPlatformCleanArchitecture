using Application.Features.OrganizationTypes.Constants;
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

namespace Application.Features.OrganizationTypes.Commands.Delete;

public class DeleteOrganizationTypeCommand : IRequest<DeletedOrganizationTypeResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, OrganizationTypesOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetOrganizationTypes";

    public class DeleteOrganizationTypeCommandHandler : IRequestHandler<DeleteOrganizationTypeCommand, DeletedOrganizationTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOrganizationTypeRepository _organizationTypeRepository;
        private readonly OrganizationTypeBusinessRules _organizationTypeBusinessRules;

        public DeleteOrganizationTypeCommandHandler(IMapper mapper, IOrganizationTypeRepository organizationTypeRepository,
                                         OrganizationTypeBusinessRules organizationTypeBusinessRules)
        {
            _mapper = mapper;
            _organizationTypeRepository = organizationTypeRepository;
            _organizationTypeBusinessRules = organizationTypeBusinessRules;
        }

        public async Task<DeletedOrganizationTypeResponse> Handle(DeleteOrganizationTypeCommand request, CancellationToken cancellationToken)
        {
            OrganizationType? organizationType = await _organizationTypeRepository.GetAsync(predicate: ot => ot.Id == request.Id, cancellationToken: cancellationToken);
            await _organizationTypeBusinessRules.OrganizationTypeShouldExistWhenSelected(organizationType);

            await _organizationTypeRepository.DeleteAsync(organizationType!);

            DeletedOrganizationTypeResponse response = _mapper.Map<DeletedOrganizationTypeResponse>(organizationType);
            return response;
        }
    }
}
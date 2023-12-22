using Application.Features.Organizations.Constants;
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

namespace Application.Features.Organizations.Commands.Delete;

public class DeleteOrganizationCommand : IRequest<DeletedOrganizationResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, OrganizationsOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetOrganizations";

    public class DeleteOrganizationCommandHandler : IRequestHandler<DeleteOrganizationCommand, DeletedOrganizationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly OrganizationBusinessRules _organizationBusinessRules;

        public DeleteOrganizationCommandHandler(IMapper mapper, IOrganizationRepository organizationRepository,
                                         OrganizationBusinessRules organizationBusinessRules)
        {
            _mapper = mapper;
            _organizationRepository = organizationRepository;
            _organizationBusinessRules = organizationBusinessRules;
        }

        public async Task<DeletedOrganizationResponse> Handle(DeleteOrganizationCommand request, CancellationToken cancellationToken)
        {
            Organization? organization = await _organizationRepository.GetAsync(predicate: o => o.Id == request.Id, cancellationToken: cancellationToken);
            await _organizationBusinessRules.OrganizationShouldExistWhenSelected(organization);

            await _organizationRepository.DeleteAsync(organization!);

            DeletedOrganizationResponse response = _mapper.Map<DeletedOrganizationResponse>(organization);
            return response;
        }
    }
}
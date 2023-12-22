using Application.Features.GraduationStatuses.Constants;
using Application.Features.GraduationStatuses.Constants;
using Application.Features.GraduationStatuses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.GraduationStatuses.Constants.GraduationStatusesOperationClaims;

namespace Application.Features.GraduationStatuses.Commands.Delete;

public class DeleteGraduationStatusCommand : IRequest<DeletedGraduationStatusResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, GraduationStatusesOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetGraduationStatus";

    public class DeleteGraduationStatusCommandHandler : IRequestHandler<DeleteGraduationStatusCommand, DeletedGraduationStatusResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGraduationStatusRepository _graduationStatusRepository;
        private readonly GraduationStatusBusinessRules _graduationStatusBusinessRules;

        public DeleteGraduationStatusCommandHandler(IMapper mapper, IGraduationStatusRepository graduationStatusRepository,
                                         GraduationStatusBusinessRules graduationStatusBusinessRules)
        {
            _mapper = mapper;
            _graduationStatusRepository = graduationStatusRepository;
            _graduationStatusBusinessRules = graduationStatusBusinessRules;
        }

        public async Task<DeletedGraduationStatusResponse> Handle(DeleteGraduationStatusCommand request, CancellationToken cancellationToken)
        {
            GraduationStatus? graduationStatus = await _graduationStatusRepository.GetAsync(predicate: gs => gs.Id == request.Id, cancellationToken: cancellationToken);
            await _graduationStatusBusinessRules.GraduationStatusShouldExistWhenSelected(graduationStatus);

            await _graduationStatusRepository.DeleteAsync(graduationStatus!);

            DeletedGraduationStatusResponse response = _mapper.Map<DeletedGraduationStatusResponse>(graduationStatus);
            return response;
        }
    }
}
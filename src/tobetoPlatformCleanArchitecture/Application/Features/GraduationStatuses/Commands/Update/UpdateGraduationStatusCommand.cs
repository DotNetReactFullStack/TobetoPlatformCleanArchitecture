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

namespace Application.Features.GraduationStatuses.Commands.Update;

public class UpdateGraduationStatusCommand : IRequest<UpdatedGraduationStatusResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Priority { get; set; }
    public bool Visibility { get; set; }

    public string[] Roles => new[] { Admin, Write, GraduationStatusesOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetGraduationStatus";

    public class UpdateGraduationStatusCommandHandler : IRequestHandler<UpdateGraduationStatusCommand, UpdatedGraduationStatusResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGraduationStatusRepository _graduationStatusRepository;
        private readonly GraduationStatusBusinessRules _graduationStatusBusinessRules;

        public UpdateGraduationStatusCommandHandler(IMapper mapper, IGraduationStatusRepository graduationStatusRepository,
                                         GraduationStatusBusinessRules graduationStatusBusinessRules)
        {
            _mapper = mapper;
            _graduationStatusRepository = graduationStatusRepository;
            _graduationStatusBusinessRules = graduationStatusBusinessRules;
        }

        public async Task<UpdatedGraduationStatusResponse> Handle(UpdateGraduationStatusCommand request, CancellationToken cancellationToken)
        {
            GraduationStatus? graduationStatus = await _graduationStatusRepository.GetAsync(predicate: gs => gs.Id == request.Id, cancellationToken: cancellationToken);
            await _graduationStatusBusinessRules.GraduationStatusShouldExistWhenSelected(graduationStatus);
            graduationStatus = _mapper.Map(request, graduationStatus);

            await _graduationStatusRepository.UpdateAsync(graduationStatus!);

            UpdatedGraduationStatusResponse response = _mapper.Map<UpdatedGraduationStatusResponse>(graduationStatus);
            return response;
        }
    }
}
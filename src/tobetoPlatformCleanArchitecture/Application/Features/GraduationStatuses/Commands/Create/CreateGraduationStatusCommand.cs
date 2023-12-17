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
using Application.Features.GraduationStatuses.Constants;

namespace Application.Features.GraduationStatuses.Commands.Create;

public class CreateGraduationStatusCommand : IRequest<CreatedGraduationStatusResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string Name { get; set; }
    public int Priority { get; set; }
    public bool Visibility { get; set; }

    public string[] Roles => new[] { Admin, Write, GraduationStatusesOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetGraduationStatus";

    public class CreateGraduationStatusCommandHandler : IRequestHandler<CreateGraduationStatusCommand, CreatedGraduationStatusResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGraduationStatusRepository _graduationStatusRepository;
        private readonly GraduationStatusBusinessRules _graduationStatusBusinessRules;

        public CreateGraduationStatusCommandHandler(IMapper mapper, IGraduationStatusRepository graduationStatusRepository,
                                         GraduationStatusBusinessRules graduationStatusBusinessRules)
        {
            _mapper = mapper;
            _graduationStatusRepository = graduationStatusRepository;
            _graduationStatusBusinessRules = graduationStatusBusinessRules;
        }

        public async Task<CreatedGraduationStatusResponse> Handle(CreateGraduationStatusCommand request, CancellationToken cancellationToken)
        {
            GraduationStatus graduationStatus = _mapper.Map<GraduationStatus>(request);

            await _graduationStatusRepository.AddAsync(graduationStatus);

            CreatedGraduationStatusResponse response = _mapper.Map<CreatedGraduationStatusResponse>(graduationStatus);
            return response;
        }
    }
}
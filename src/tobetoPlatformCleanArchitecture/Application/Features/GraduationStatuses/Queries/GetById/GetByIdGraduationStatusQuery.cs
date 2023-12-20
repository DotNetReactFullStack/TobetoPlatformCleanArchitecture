using Application.Features.GraduationStatuses.Constants;
using Application.Features.GraduationStatuses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.GraduationStatuses.Constants.GraduationStatusesOperationClaims;

namespace Application.Features.GraduationStatuses.Queries.GetById;

public class GetByIdGraduationStatusQuery : IRequest<GetByIdGraduationStatusResponse>
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdGraduationStatusQueryHandler : IRequestHandler<GetByIdGraduationStatusQuery, GetByIdGraduationStatusResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGraduationStatusRepository _graduationStatusRepository;
        private readonly GraduationStatusBusinessRules _graduationStatusBusinessRules;

        public GetByIdGraduationStatusQueryHandler(IMapper mapper, IGraduationStatusRepository graduationStatusRepository, GraduationStatusBusinessRules graduationStatusBusinessRules)
        {
            _mapper = mapper;
            _graduationStatusRepository = graduationStatusRepository;
            _graduationStatusBusinessRules = graduationStatusBusinessRules;
        }

        public async Task<GetByIdGraduationStatusResponse> Handle(GetByIdGraduationStatusQuery request, CancellationToken cancellationToken)
        {
            GraduationStatus? graduationStatus = await _graduationStatusRepository.GetAsync(predicate: gs => gs.Id == request.Id, cancellationToken: cancellationToken);
            await _graduationStatusBusinessRules.GraduationStatusShouldExistWhenSelected(graduationStatus);

            GetByIdGraduationStatusResponse response = _mapper.Map<GetByIdGraduationStatusResponse>(graduationStatus);
            return response;
        }
    }
}
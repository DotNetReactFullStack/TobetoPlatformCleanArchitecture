using Application.Features.GraduationStatus.Constants;
using Application.Features.GraduationStatus.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.GraduationStatus.Constants.GraduationStatusOperationClaims;

namespace Application.Features.GraduationStatus.Queries.GetById;

public class GetByIdGraduationStatusQuery : IRequest<GetByIdGraduationStatusResponse>, ISecuredRequest
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
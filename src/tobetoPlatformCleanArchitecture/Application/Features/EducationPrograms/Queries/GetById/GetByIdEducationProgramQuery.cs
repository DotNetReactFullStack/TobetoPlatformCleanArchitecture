using Application.Features.EducationPrograms.Constants;
using Application.Features.EducationPrograms.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.EducationPrograms.Constants.EducationProgramsOperationClaims;

namespace Application.Features.EducationPrograms.Queries.GetById;

public class GetByIdEducationProgramQuery : IRequest<GetByIdEducationProgramResponse>
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdEducationProgramQueryHandler : IRequestHandler<GetByIdEducationProgramQuery, GetByIdEducationProgramResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEducationProgramRepository _educationProgramRepository;
        private readonly EducationProgramBusinessRules _educationProgramBusinessRules;

        public GetByIdEducationProgramQueryHandler(IMapper mapper, IEducationProgramRepository educationProgramRepository, EducationProgramBusinessRules educationProgramBusinessRules)
        {
            _mapper = mapper;
            _educationProgramRepository = educationProgramRepository;
            _educationProgramBusinessRules = educationProgramBusinessRules;
        }

        public async Task<GetByIdEducationProgramResponse> Handle(GetByIdEducationProgramQuery request, CancellationToken cancellationToken)
        {
            EducationProgram? educationProgram = await _educationProgramRepository.GetAsync(predicate: ep => ep.Id == request.Id, cancellationToken: cancellationToken);
            await _educationProgramBusinessRules.EducationProgramShouldExistWhenSelected(educationProgram);

            GetByIdEducationProgramResponse response = _mapper.Map<GetByIdEducationProgramResponse>(educationProgram);
            return response;
        }
    }
}
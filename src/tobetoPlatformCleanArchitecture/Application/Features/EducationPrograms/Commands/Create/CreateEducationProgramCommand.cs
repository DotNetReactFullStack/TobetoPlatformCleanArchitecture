using Application.Features.EducationPrograms.Constants;
using Application.Features.EducationPrograms.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.EducationPrograms.Constants.EducationProgramsOperationClaims;

namespace Application.Features.EducationPrograms.Commands.Create;

public class CreateEducationProgramCommand : IRequest<CreatedEducationProgramResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int CollegeId { get; set; }
    public string Name { get; set; }
    public bool Visibility { get; set; }

    public string[] Roles => new[] { Admin, Write, EducationProgramsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetEducationPrograms";

    public class CreateEducationProgramCommandHandler : IRequestHandler<CreateEducationProgramCommand, CreatedEducationProgramResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEducationProgramRepository _educationProgramRepository;
        private readonly EducationProgramBusinessRules _educationProgramBusinessRules;

        public CreateEducationProgramCommandHandler(IMapper mapper, IEducationProgramRepository educationProgramRepository,
                                         EducationProgramBusinessRules educationProgramBusinessRules)
        {
            _mapper = mapper;
            _educationProgramRepository = educationProgramRepository;
            _educationProgramBusinessRules = educationProgramBusinessRules;
        }

        public async Task<CreatedEducationProgramResponse> Handle(CreateEducationProgramCommand request, CancellationToken cancellationToken)
        {
            EducationProgram educationProgram = _mapper.Map<EducationProgram>(request);

            await _educationProgramRepository.AddAsync(educationProgram);

            CreatedEducationProgramResponse response = _mapper.Map<CreatedEducationProgramResponse>(educationProgram);
            return response;
        }
    }
}
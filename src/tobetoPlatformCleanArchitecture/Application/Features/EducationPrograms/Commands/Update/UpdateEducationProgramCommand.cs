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

namespace Application.Features.EducationPrograms.Commands.Update;

public class UpdateEducationProgramCommand : IRequest<UpdatedEducationProgramResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public int CollegeId { get; set; }
    public string Name { get; set; }
    public bool Visibility { get; set; }

    public string[] Roles => new[] { Admin, Write, EducationProgramsOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetEducationPrograms";

    public class UpdateEducationProgramCommandHandler : IRequestHandler<UpdateEducationProgramCommand, UpdatedEducationProgramResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEducationProgramRepository _educationProgramRepository;
        private readonly EducationProgramBusinessRules _educationProgramBusinessRules;

        public UpdateEducationProgramCommandHandler(IMapper mapper, IEducationProgramRepository educationProgramRepository,
                                         EducationProgramBusinessRules educationProgramBusinessRules)
        {
            _mapper = mapper;
            _educationProgramRepository = educationProgramRepository;
            _educationProgramBusinessRules = educationProgramBusinessRules;
        }

        public async Task<UpdatedEducationProgramResponse> Handle(UpdateEducationProgramCommand request, CancellationToken cancellationToken)
        {
            EducationProgram? educationProgram = await _educationProgramRepository.GetAsync(predicate: ep => ep.Id == request.Id, cancellationToken: cancellationToken);
            await _educationProgramBusinessRules.EducationProgramShouldExistWhenSelected(educationProgram);
            educationProgram = _mapper.Map(request, educationProgram);

            await _educationProgramRepository.UpdateAsync(educationProgram!);

            UpdatedEducationProgramResponse response = _mapper.Map<UpdatedEducationProgramResponse>(educationProgram);
            return response;
        }
    }
}
using Application.Features.EducationPrograms.Constants;
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

namespace Application.Features.EducationPrograms.Commands.Delete;

public class DeleteEducationProgramCommand : IRequest<DeletedEducationProgramResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, EducationProgramsOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetEducationPrograms";

    public class DeleteEducationProgramCommandHandler : IRequestHandler<DeleteEducationProgramCommand, DeletedEducationProgramResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEducationProgramRepository _educationProgramRepository;
        private readonly EducationProgramBusinessRules _educationProgramBusinessRules;

        public DeleteEducationProgramCommandHandler(IMapper mapper, IEducationProgramRepository educationProgramRepository,
                                         EducationProgramBusinessRules educationProgramBusinessRules)
        {
            _mapper = mapper;
            _educationProgramRepository = educationProgramRepository;
            _educationProgramBusinessRules = educationProgramBusinessRules;
        }

        public async Task<DeletedEducationProgramResponse> Handle(DeleteEducationProgramCommand request, CancellationToken cancellationToken)
        {
            EducationProgram? educationProgram = await _educationProgramRepository.GetAsync(predicate: ep => ep.Id == request.Id, cancellationToken: cancellationToken);
            await _educationProgramBusinessRules.EducationProgramShouldExistWhenSelected(educationProgram);

            await _educationProgramRepository.DeleteAsync(educationProgram!);

            DeletedEducationProgramResponse response = _mapper.Map<DeletedEducationProgramResponse>(educationProgram);
            return response;
        }
    }
}
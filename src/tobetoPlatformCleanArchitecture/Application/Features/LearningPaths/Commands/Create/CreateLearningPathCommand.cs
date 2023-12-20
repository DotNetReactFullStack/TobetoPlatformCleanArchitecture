using Application.Features.LearningPaths.Constants;
using Application.Features.LearningPaths.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.LearningPaths.Constants.LearningPathsOperationClaims;

namespace Application.Features.LearningPaths.Commands.Create;

public class CreateLearningPathCommand : IRequest<CreatedLearningPathResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string Name { get; set; }
    public bool Visibility { get; set; }
    public DateTime StartingTime { get; set; }
    public DateTime EndingTime { get; set; }
    public int NumberOfLikes { get; set; }
    public int TotalDuration { get; set; }

    public string[] Roles => new[] { Admin, Write, LearningPathsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetLearningPaths";

    public class CreateLearningPathCommandHandler : IRequestHandler<CreateLearningPathCommand, CreatedLearningPathResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILearningPathRepository _learningPathRepository;
        private readonly LearningPathBusinessRules _learningPathBusinessRules;

        public CreateLearningPathCommandHandler(IMapper mapper, ILearningPathRepository learningPathRepository,
                                         LearningPathBusinessRules learningPathBusinessRules)
        {
            _mapper = mapper;
            _learningPathRepository = learningPathRepository;
            _learningPathBusinessRules = learningPathBusinessRules;
        }

        public async Task<CreatedLearningPathResponse> Handle(CreateLearningPathCommand request, CancellationToken cancellationToken)
        {
            LearningPath learningPath = _mapper.Map<LearningPath>(request);

            await _learningPathRepository.AddAsync(learningPath);

            CreatedLearningPathResponse response = _mapper.Map<CreatedLearningPathResponse>(learningPath);
            return response;
        }
    }
}
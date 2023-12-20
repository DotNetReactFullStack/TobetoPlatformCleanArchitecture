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

namespace Application.Features.LearningPaths.Commands.Update;

public class UpdateLearningPathCommand : IRequest<UpdatedLearningPathResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool Visibility { get; set; }
    public DateTime StartingTime { get; set; }
    public DateTime EndingTime { get; set; }
    public int NumberOfLikes { get; set; }
    public int TotalDuration { get; set; }

    public string[] Roles => new[] { Admin, Write, LearningPathsOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetLearningPaths";

    public class UpdateLearningPathCommandHandler : IRequestHandler<UpdateLearningPathCommand, UpdatedLearningPathResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILearningPathRepository _learningPathRepository;
        private readonly LearningPathBusinessRules _learningPathBusinessRules;

        public UpdateLearningPathCommandHandler(IMapper mapper, ILearningPathRepository learningPathRepository,
                                         LearningPathBusinessRules learningPathBusinessRules)
        {
            _mapper = mapper;
            _learningPathRepository = learningPathRepository;
            _learningPathBusinessRules = learningPathBusinessRules;
        }

        public async Task<UpdatedLearningPathResponse> Handle(UpdateLearningPathCommand request, CancellationToken cancellationToken)
        {
            LearningPath? learningPath = await _learningPathRepository.GetAsync(predicate: lp => lp.Id == request.Id, cancellationToken: cancellationToken);
            await _learningPathBusinessRules.LearningPathShouldExistWhenSelected(learningPath);
            learningPath = _mapper.Map(request, learningPath);

            await _learningPathRepository.UpdateAsync(learningPath!);

            UpdatedLearningPathResponse response = _mapper.Map<UpdatedLearningPathResponse>(learningPath);
            return response;
        }
    }
}
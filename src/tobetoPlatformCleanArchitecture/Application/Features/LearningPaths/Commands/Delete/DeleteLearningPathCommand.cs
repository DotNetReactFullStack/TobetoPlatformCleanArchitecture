using Application.Features.LearningPaths.Constants;
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

namespace Application.Features.LearningPaths.Commands.Delete;

public class DeleteLearningPathCommand : IRequest<DeletedLearningPathResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, LearningPathsOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetLearningPaths";

    public class DeleteLearningPathCommandHandler : IRequestHandler<DeleteLearningPathCommand, DeletedLearningPathResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILearningPathRepository _learningPathRepository;
        private readonly LearningPathBusinessRules _learningPathBusinessRules;

        public DeleteLearningPathCommandHandler(IMapper mapper, ILearningPathRepository learningPathRepository,
                                         LearningPathBusinessRules learningPathBusinessRules)
        {
            _mapper = mapper;
            _learningPathRepository = learningPathRepository;
            _learningPathBusinessRules = learningPathBusinessRules;
        }

        public async Task<DeletedLearningPathResponse> Handle(DeleteLearningPathCommand request, CancellationToken cancellationToken)
        {
            LearningPath? learningPath = await _learningPathRepository.GetAsync(predicate: lp => lp.Id == request.Id, cancellationToken: cancellationToken);
            await _learningPathBusinessRules.LearningPathShouldExistWhenSelected(learningPath);

            await _learningPathRepository.DeleteAsync(learningPath!);

            DeletedLearningPathResponse response = _mapper.Map<DeletedLearningPathResponse>(learningPath);
            return response;
        }
    }
}
using Application.Features.CourseLearningPaths.Constants;
using Application.Features.CourseLearningPaths.Constants;
using Application.Features.CourseLearningPaths.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.CourseLearningPaths.Constants.CourseLearningPathsOperationClaims;

namespace Application.Features.CourseLearningPaths.Commands.Delete;

public class DeleteCourseLearningPathCommand : IRequest<DeletedCourseLearningPathResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, CourseLearningPathsOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetCourseLearningPaths";

    public class DeleteCourseLearningPathCommandHandler : IRequestHandler<DeleteCourseLearningPathCommand, DeletedCourseLearningPathResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICourseLearningPathRepository _courseLearningPathRepository;
        private readonly CourseLearningPathBusinessRules _courseLearningPathBusinessRules;

        public DeleteCourseLearningPathCommandHandler(IMapper mapper, ICourseLearningPathRepository courseLearningPathRepository,
                                         CourseLearningPathBusinessRules courseLearningPathBusinessRules)
        {
            _mapper = mapper;
            _courseLearningPathRepository = courseLearningPathRepository;
            _courseLearningPathBusinessRules = courseLearningPathBusinessRules;
        }

        public async Task<DeletedCourseLearningPathResponse> Handle(DeleteCourseLearningPathCommand request, CancellationToken cancellationToken)
        {
            CourseLearningPath? courseLearningPath = await _courseLearningPathRepository.GetAsync(predicate: clp => clp.Id == request.Id, cancellationToken: cancellationToken);
            await _courseLearningPathBusinessRules.CourseLearningPathShouldExistWhenSelected(courseLearningPath);

            await _courseLearningPathRepository.DeleteAsync(courseLearningPath!);

            DeletedCourseLearningPathResponse response = _mapper.Map<DeletedCourseLearningPathResponse>(courseLearningPath);
            return response;
        }
    }
}
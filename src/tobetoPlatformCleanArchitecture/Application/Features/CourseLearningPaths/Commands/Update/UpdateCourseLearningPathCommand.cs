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

namespace Application.Features.CourseLearningPaths.Commands.Update;

public class UpdateCourseLearningPathCommand : IRequest<UpdatedCourseLearningPathResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public int CourseId { get; set; }
    public int PathId { get; set; }
    public bool Visibility { get; set; }

    public string[] Roles => new[] { Admin, Write, CourseLearningPathsOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetCourseLearningPaths";

    public class UpdateCourseLearningPathCommandHandler : IRequestHandler<UpdateCourseLearningPathCommand, UpdatedCourseLearningPathResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICourseLearningPathRepository _courseLearningPathRepository;
        private readonly CourseLearningPathBusinessRules _courseLearningPathBusinessRules;

        public UpdateCourseLearningPathCommandHandler(IMapper mapper, ICourseLearningPathRepository courseLearningPathRepository,
                                         CourseLearningPathBusinessRules courseLearningPathBusinessRules)
        {
            _mapper = mapper;
            _courseLearningPathRepository = courseLearningPathRepository;
            _courseLearningPathBusinessRules = courseLearningPathBusinessRules;
        }

        public async Task<UpdatedCourseLearningPathResponse> Handle(UpdateCourseLearningPathCommand request, CancellationToken cancellationToken)
        {
            CourseLearningPath? courseLearningPath = await _courseLearningPathRepository.GetAsync(predicate: clp => clp.Id == request.Id, cancellationToken: cancellationToken);
            await _courseLearningPathBusinessRules.CourseLearningPathShouldExistWhenSelected(courseLearningPath);
            courseLearningPath = _mapper.Map(request, courseLearningPath);

            await _courseLearningPathRepository.UpdateAsync(courseLearningPath!);

            UpdatedCourseLearningPathResponse response = _mapper.Map<UpdatedCourseLearningPathResponse>(courseLearningPath);
            return response;
        }
    }
}
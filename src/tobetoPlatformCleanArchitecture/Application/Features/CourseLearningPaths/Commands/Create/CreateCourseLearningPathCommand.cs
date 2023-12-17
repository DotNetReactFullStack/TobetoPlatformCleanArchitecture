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

namespace Application.Features.CourseLearningPaths.Commands.Create;

public class CreateCourseLearningPathCommand : IRequest<CreatedCourseLearningPathResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int CourseId { get; set; }
    public int PathId { get; set; }
    public bool Visibility { get; set; }

    public string[] Roles => new[] { Admin, Write, CourseLearningPathsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetCourseLearningPaths";

    public class CreateCourseLearningPathCommandHandler : IRequestHandler<CreateCourseLearningPathCommand, CreatedCourseLearningPathResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICourseLearningPathRepository _courseLearningPathRepository;
        private readonly CourseLearningPathBusinessRules _courseLearningPathBusinessRules;

        public CreateCourseLearningPathCommandHandler(IMapper mapper, ICourseLearningPathRepository courseLearningPathRepository,
                                         CourseLearningPathBusinessRules courseLearningPathBusinessRules)
        {
            _mapper = mapper;
            _courseLearningPathRepository = courseLearningPathRepository;
            _courseLearningPathBusinessRules = courseLearningPathBusinessRules;
        }

        public async Task<CreatedCourseLearningPathResponse> Handle(CreateCourseLearningPathCommand request, CancellationToken cancellationToken)
        {
            CourseLearningPath courseLearningPath = _mapper.Map<CourseLearningPath>(request);

            await _courseLearningPathRepository.AddAsync(courseLearningPath);

            CreatedCourseLearningPathResponse response = _mapper.Map<CreatedCourseLearningPathResponse>(courseLearningPath);
            return response;
        }
    }
}
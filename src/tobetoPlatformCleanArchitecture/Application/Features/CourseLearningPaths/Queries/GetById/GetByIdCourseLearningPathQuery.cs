using Application.Features.CourseLearningPaths.Constants;
using Application.Features.CourseLearningPaths.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.CourseLearningPaths.Constants.CourseLearningPathsOperationClaims;

namespace Application.Features.CourseLearningPaths.Queries.GetById;

public class GetByIdCourseLearningPathQuery : IRequest<GetByIdCourseLearningPathResponse>
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdCourseLearningPathQueryHandler : IRequestHandler<GetByIdCourseLearningPathQuery, GetByIdCourseLearningPathResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICourseLearningPathRepository _courseLearningPathRepository;
        private readonly CourseLearningPathBusinessRules _courseLearningPathBusinessRules;

        public GetByIdCourseLearningPathQueryHandler(IMapper mapper, ICourseLearningPathRepository courseLearningPathRepository, CourseLearningPathBusinessRules courseLearningPathBusinessRules)
        {
            _mapper = mapper;
            _courseLearningPathRepository = courseLearningPathRepository;
            _courseLearningPathBusinessRules = courseLearningPathBusinessRules;
        }

        public async Task<GetByIdCourseLearningPathResponse> Handle(GetByIdCourseLearningPathQuery request, CancellationToken cancellationToken)
        {
            CourseLearningPath? courseLearningPath = await _courseLearningPathRepository.GetAsync(predicate: clp => clp.Id == request.Id, cancellationToken: cancellationToken);
            await _courseLearningPathBusinessRules.CourseLearningPathShouldExistWhenSelected(courseLearningPath);

            GetByIdCourseLearningPathResponse response = _mapper.Map<GetByIdCourseLearningPathResponse>(courseLearningPath);
            return response;
        }
    }
}
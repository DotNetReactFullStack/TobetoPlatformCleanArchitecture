
using Application.Features.CourseLearningPaths.Queries.GetList;
using Application.Features.OperationClaims.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using static Application.Features.CourseLearningPaths.Constants.CourseLearningPathsOperationClaims;

namespace Application.Features.CourseLearningPaths.Queries.GetListByLearningPathId;
public class GetListByLearningPathIdCourseLearningPathQuery : IRequest<GetListResponse<GetListByLearningPathIdCourseLearningPathListItemDto>>//, ISecuredRequest, ICachableRequest
{
    public int LearningPathId { get; set; }
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read, GeneralOperationClaims.Instructor, GeneralOperationClaims.Student };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListCourse({LearningPathId})LearningPaths({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetCourseLearningPaths";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListByLearningPathIdCourseLearningPathQueryHandler : IRequestHandler<GetListByLearningPathIdCourseLearningPathQuery, GetListResponse<GetListByLearningPathIdCourseLearningPathListItemDto>>
    {
        private readonly ICourseLearningPathRepository _courseLearningPathRepository;
        private readonly IMapper _mapper;

        public GetListByLearningPathIdCourseLearningPathQueryHandler(ICourseLearningPathRepository courseLearningPathRepository, IMapper mapper)
        {
            _courseLearningPathRepository = courseLearningPathRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListByLearningPathIdCourseLearningPathListItemDto>> Handle(GetListByLearningPathIdCourseLearningPathQuery request, CancellationToken cancellationToken)
        {
            IPaginate<CourseLearningPath> courseLearningPaths = await _courseLearningPathRepository.GetListAsync(
                predicate: clp => clp.LearningPathId == request.LearningPathId,
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListByLearningPathIdCourseLearningPathListItemDto> response = _mapper.Map<GetListResponse<GetListByLearningPathIdCourseLearningPathListItemDto>>(courseLearningPaths);
            return response;
        }
    }
}

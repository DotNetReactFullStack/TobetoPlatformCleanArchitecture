using Application.Features.CourseLearningPaths.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.CourseLearningPaths.Constants.CourseLearningPathsOperationClaims;

namespace Application.Features.CourseLearningPaths.Queries.GetList;

public class GetListCourseLearningPathQuery : IRequest<GetListResponse<GetListCourseLearningPathListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListCourseLearningPaths({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetCourseLearningPaths";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListCourseLearningPathQueryHandler : IRequestHandler<GetListCourseLearningPathQuery, GetListResponse<GetListCourseLearningPathListItemDto>>
    {
        private readonly ICourseLearningPathRepository _courseLearningPathRepository;
        private readonly IMapper _mapper;

        public GetListCourseLearningPathQueryHandler(ICourseLearningPathRepository courseLearningPathRepository, IMapper mapper)
        {
            _courseLearningPathRepository = courseLearningPathRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCourseLearningPathListItemDto>> Handle(GetListCourseLearningPathQuery request, CancellationToken cancellationToken)
        {
            IPaginate<CourseLearningPath> courseLearningPaths = await _courseLearningPathRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCourseLearningPathListItemDto> response = _mapper.Map<GetListResponse<GetListCourseLearningPathListItemDto>>(courseLearningPaths);
            return response;
        }
    }
}
using Application.Features.Courses.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.Courses.Constants.CoursesOperationClaims;

namespace Application.Features.Courses.Queries.GetList;

public class GetListCourseQuery : IRequest<GetListResponse<GetListCourseListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListCourses({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetCourses";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListCourseQueryHandler : IRequestHandler<GetListCourseQuery, GetListResponse<GetListCourseListItemDto>>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public GetListCourseQueryHandler(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCourseListItemDto>> Handle(GetListCourseQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Course> courses = await _courseRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCourseListItemDto> response = _mapper.Map<GetListResponse<GetListCourseListItemDto>>(courses);
            return response;
        }
    }
}
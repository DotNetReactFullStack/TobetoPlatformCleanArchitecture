using Application.Features.CourseCategories.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.CourseCategories.Constants.CourseCategoriesOperationClaims;

namespace Application.Features.CourseCategories.Queries.GetList;

public class GetListCourseCategoryQuery : IRequest<GetListResponse<GetListCourseCategoryListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListCourseCategories({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetCourseCategories";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListCourseCategoryQueryHandler : IRequestHandler<GetListCourseCategoryQuery, GetListResponse<GetListCourseCategoryListItemDto>>
    {
        private readonly ICourseCategoryRepository _courseCategoryRepository;
        private readonly IMapper _mapper;

        public GetListCourseCategoryQueryHandler(ICourseCategoryRepository courseCategoryRepository, IMapper mapper)
        {
            _courseCategoryRepository = courseCategoryRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCourseCategoryListItemDto>> Handle(GetListCourseCategoryQuery request, CancellationToken cancellationToken)
        {
            IPaginate<CourseCategory> courseCategories = await _courseCategoryRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCourseCategoryListItemDto> response = _mapper.Map<GetListResponse<GetListCourseCategoryListItemDto>>(courseCategories);
            return response;
        }
    }
}
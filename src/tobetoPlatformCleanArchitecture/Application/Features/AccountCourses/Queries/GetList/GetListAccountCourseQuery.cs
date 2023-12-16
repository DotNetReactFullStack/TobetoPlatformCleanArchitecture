using Application.Features.AccountCourses.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.AccountCourses.Constants.AccountCoursesOperationClaims;

namespace Application.Features.AccountCourses.Queries.GetList;

public class GetListAccountCourseQuery : IRequest<GetListResponse<GetListAccountCourseListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListAccountCourses({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetAccountCourses";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListAccountCourseQueryHandler : IRequestHandler<GetListAccountCourseQuery, GetListResponse<GetListAccountCourseListItemDto>>
    {
        private readonly IAccountCourseRepository _accountCourseRepository;
        private readonly IMapper _mapper;

        public GetListAccountCourseQueryHandler(IAccountCourseRepository accountCourseRepository, IMapper mapper)
        {
            _accountCourseRepository = accountCourseRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListAccountCourseListItemDto>> Handle(GetListAccountCourseQuery request, CancellationToken cancellationToken)
        {
            IPaginate<AccountCourse> accountCourses = await _accountCourseRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListAccountCourseListItemDto> response = _mapper.Map<GetListResponse<GetListAccountCourseListItemDto>>(accountCourses);
            return response;
        }
    }
}
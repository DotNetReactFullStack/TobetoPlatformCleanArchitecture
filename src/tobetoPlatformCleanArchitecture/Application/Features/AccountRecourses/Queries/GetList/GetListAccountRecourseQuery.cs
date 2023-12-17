using Application.Features.AccountRecourses.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.AccountRecourses.Constants.AccountRecoursesOperationClaims;

namespace Application.Features.AccountRecourses.Queries.GetList;

public class GetListAccountRecourseQuery : IRequest<GetListResponse<GetListAccountRecourseListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListAccountRecourses({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetAccountRecourses";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListAccountRecourseQueryHandler : IRequestHandler<GetListAccountRecourseQuery, GetListResponse<GetListAccountRecourseListItemDto>>
    {
        private readonly IAccountRecourseRepository _accountRecourseRepository;
        private readonly IMapper _mapper;

        public GetListAccountRecourseQueryHandler(IAccountRecourseRepository accountRecourseRepository, IMapper mapper)
        {
            _accountRecourseRepository = accountRecourseRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListAccountRecourseListItemDto>> Handle(GetListAccountRecourseQuery request, CancellationToken cancellationToken)
        {
            IPaginate<AccountRecourse> accountRecourses = await _accountRecourseRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListAccountRecourseListItemDto> response = _mapper.Map<GetListResponse<GetListAccountRecourseListItemDto>>(accountRecourses);
            return response;
        }
    }
}
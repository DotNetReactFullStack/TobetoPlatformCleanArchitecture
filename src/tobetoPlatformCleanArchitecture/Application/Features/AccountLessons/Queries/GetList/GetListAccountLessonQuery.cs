using Application.Features.AccountLessons.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.AccountLessons.Constants.AccountLessonsOperationClaims;

namespace Application.Features.AccountLessons.Queries.GetList;

public class GetListAccountLessonQuery : IRequest<GetListResponse<GetListAccountLessonListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListAccountLessons({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetAccountLessons";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListAccountLessonQueryHandler : IRequestHandler<GetListAccountLessonQuery, GetListResponse<GetListAccountLessonListItemDto>>
    {
        private readonly IAccountLessonRepository _accountLessonRepository;
        private readonly IMapper _mapper;

        public GetListAccountLessonQueryHandler(IAccountLessonRepository accountLessonRepository, IMapper mapper)
        {
            _accountLessonRepository = accountLessonRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListAccountLessonListItemDto>> Handle(GetListAccountLessonQuery request, CancellationToken cancellationToken)
        {
            IPaginate<AccountLesson> accountLessons = await _accountLessonRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListAccountLessonListItemDto> response = _mapper.Map<GetListResponse<GetListAccountLessonListItemDto>>(accountLessons);
            return response;
        }
    }
}
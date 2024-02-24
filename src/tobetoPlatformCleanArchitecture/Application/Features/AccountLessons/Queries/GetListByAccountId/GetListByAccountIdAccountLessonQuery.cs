using Application.Features.AccountLessons.Queries.GetList;
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
using static Application.Features.AccountLessons.Constants.AccountLessonsOperationClaims;


namespace Application.Features.AccountLessons.Queries.GetListByAccountId;
public class GetListByAccountIdAccountLessonQuery : IRequest<GetListResponse<GetListByAccountIdAccountLessonListItemDto>>, ISecuredRequest, ICachableRequest
{
    public int AccountId { get; set; }
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read, GeneralOperationClaims.Instructor, GeneralOperationClaims.Student };


    public bool BypassCache { get; }
    public string CacheKey => $"GetListByAccountId({AccountId})AccountLessons({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetAccountLessons";
    public TimeSpan? SlidingExpiration { get; }
    public class GetListByAccountIdAccountLessonQueryHandler : IRequestHandler<GetListByAccountIdAccountLessonQuery, GetListResponse<GetListByAccountIdAccountLessonListItemDto>>
    {
        private readonly IAccountLessonRepository _accountLessonRepository;
        private readonly IMapper _mapper;

        public GetListByAccountIdAccountLessonQueryHandler(IAccountLessonRepository accountLessonRepository, IMapper mapper)
        {
            _accountLessonRepository = accountLessonRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListByAccountIdAccountLessonListItemDto>> Handle(GetListByAccountIdAccountLessonQuery request, CancellationToken cancellationToken)
        {
            IPaginate<AccountLesson> accountLessons = await _accountLessonRepository.GetListAsync(
                predicate: al => al.AccountId == request.AccountId,
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListByAccountIdAccountLessonListItemDto> response = _mapper.Map<GetListResponse<GetListByAccountIdAccountLessonListItemDto>>(accountLessons);
            return response;
        }
    }
}

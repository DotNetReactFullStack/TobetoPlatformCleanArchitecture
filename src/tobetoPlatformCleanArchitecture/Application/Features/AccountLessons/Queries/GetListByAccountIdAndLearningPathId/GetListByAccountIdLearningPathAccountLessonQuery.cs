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
using Microsoft.EntityFrameworkCore;
using static Application.Features.AccountLessons.Constants.AccountLessonsOperationClaims;


namespace Application.Features.AccountLessons.Queries.GetListByAccountIdAndLearningPathId;
public class GetListByAccountIdLearningPathAccountLessonQuery : IRequest<GetListResponse<GetListByAccountIdLearningPathAccountLessonListItemDto>>, ISecuredRequest, ICachableRequest
{
    public int AccountId { get; set; }
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read, GeneralOperationClaims.Instructor, GeneralOperationClaims.Student };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListByAccountId({AccountId})AccountLessons({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetAccountLessons";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListByAccountIdAndLearningPathIdAccountLessonQueryHandler : IRequestHandler<GetListByAccountIdLearningPathAccountLessonQuery, GetListResponse<GetListByAccountIdLearningPathAccountLessonListItemDto>>
    {
        private readonly IAccountLessonRepository _accountLessonRepository;
        private readonly IMapper _mapper;

        public GetListByAccountIdAndLearningPathIdAccountLessonQueryHandler(IAccountLessonRepository accountLessonRepository, IMapper mapper)
        {
            _accountLessonRepository = accountLessonRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListByAccountIdLearningPathAccountLessonListItemDto>> Handle(GetListByAccountIdLearningPathAccountLessonQuery request, CancellationToken cancellationToken)
        {
            IPaginate<AccountLesson> accountLessons = await _accountLessonRepository.GetListAsync(
                predicate: al => al.AccountId == request.AccountId,
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken,
                include: al => al.Include(al => al.Lesson)
                .Include(al => al.Lesson).ThenInclude(l => l.Course)
                .Include(al => al.Lesson).ThenInclude(l => l.Course).ThenInclude(c => c.CourseLearningPaths)
                .Include(al => al.Lesson).ThenInclude(l => l.Course).ThenInclude(c => c.CourseLearningPaths)
            );

            GetListResponse<GetListByAccountIdLearningPathAccountLessonListItemDto> response = _mapper.Map<GetListResponse<GetListByAccountIdLearningPathAccountLessonListItemDto>>(accountLessons);
            return response;
        }
    }
}
using Application.Features.AccountLearningPaths.Queries.GetListByAccountId;
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
using static Application.Features.AccountLearningPaths.Constants.AccountLearningPathsOperationClaims;


namespace Application.Features.AccountLearningPaths.Queries.GetListByAccountIdAndLearningPathId;
public class GetListByAccountIdAndLearningPathIdAccountLearningPathQuery : IRequest<GetListResponse<GetListByAccountIdAndLearningPathIdAccountLearningPathListItemDto>>//, ISecuredRequest, ICachableRequest
{  
    public int AccountId { get; set; }
    public int LearningPathId { get; set; }

    public PageRequest PageRequest { get; set; }
    public string[] Roles => new[] { Admin, Read, GeneralOperationClaims.Instructor, GeneralOperationClaims.Student };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListByAccountId({AccountId})AndLearningPathId({LearningPathId})AccountLearningPaths({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetAccountLearningPaths";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListByAccountIdAndLearningPathIdAccountLearningPathQueryHandler : IRequestHandler<GetListByAccountIdAndLearningPathIdAccountLearningPathQuery, GetListResponse<GetListByAccountIdAndLearningPathIdAccountLearningPathListItemDto>>
    {
        private readonly IAccountLearningPathRepository _accountLearningPathRepository;
        private readonly IMapper _mapper;

        public GetListByAccountIdAndLearningPathIdAccountLearningPathQueryHandler(IAccountLearningPathRepository accountLearningPathRepository, IMapper mapper)
        {
            _accountLearningPathRepository = accountLearningPathRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListByAccountIdAndLearningPathIdAccountLearningPathListItemDto>> Handle(GetListByAccountIdAndLearningPathIdAccountLearningPathQuery request, CancellationToken cancellationToken)
        {
            IPaginate<AccountLearningPath> accountLearningPaths = await _accountLearningPathRepository.GetListAsync(
                predicate: alp => alp.AccountId == request.AccountId && alp.LearningPathId == request.LearningPathId,
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken,
                include: alp => alp.Include(alp => alp.LearningPath)
                .Include(alp => alp.LearningPath).ThenInclude(lp => lp.CourseLearningPaths)
                .Include(alp => alp.Account.AccountCourses).ThenInclude(ac => ac.Course)
                .Include(alp => alp.Account.AccountLessons)
                .Include(alp => alp.Account.AccountLessons).ThenInclude(al => al.Lesson)
            );

            GetListResponse<GetListByAccountIdAndLearningPathIdAccountLearningPathListItemDto> response = _mapper.Map<GetListResponse<GetListByAccountIdAndLearningPathIdAccountLearningPathListItemDto>>(accountLearningPaths);
            return response;
        }
    }
}

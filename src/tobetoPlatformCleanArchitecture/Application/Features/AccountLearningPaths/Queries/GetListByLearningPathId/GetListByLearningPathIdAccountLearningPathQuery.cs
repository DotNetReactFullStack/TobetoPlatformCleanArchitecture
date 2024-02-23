using Application.Features.AccountLearningPaths.Queries.GetList;
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

namespace Application.Features.AccountLearningPaths.Queries.GetListByLearningPathId;
using static Application.Features.AccountLearningPaths.Constants.AccountLearningPathsOperationClaims;


public class GetListByLearningPathIdAccountLearningPathQuery : IRequest<GetListResponse<GetListByLearningPathIdAccountLearningPathListItemDto>>, ISecuredRequest, ICachableRequest
{
    public  int LearningPathId { get; set; }
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read, GeneralOperationClaims.Instructor, GeneralOperationClaims.Student };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListByLearningPathId({LearningPathId})AccountLearningPaths({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetAccountLearningPaths";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListByLearningPathIdAccountLearningPathQueryHandler : IRequestHandler<GetListByLearningPathIdAccountLearningPathQuery, GetListResponse<GetListByLearningPathIdAccountLearningPathListItemDto>>
    {
        private readonly IAccountLearningPathRepository _accountLearningPathRepository;
        private readonly IMapper _mapper;

        public GetListByLearningPathIdAccountLearningPathQueryHandler(IAccountLearningPathRepository accountLearningPathRepository, IMapper mapper)
        {
            _accountLearningPathRepository = accountLearningPathRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListByLearningPathIdAccountLearningPathListItemDto>> Handle(GetListByLearningPathIdAccountLearningPathQuery request, CancellationToken cancellationToken)
        {
            IPaginate<AccountLearningPath> accountLearningPaths = await _accountLearningPathRepository.GetListAsync(
                predicate: alp => alp.LearningPathId == request.LearningPathId,
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListByLearningPathIdAccountLearningPathListItemDto> response = _mapper.Map<GetListResponse<GetListByLearningPathIdAccountLearningPathListItemDto>>(accountLearningPaths);
            return response;
        }
    }
}

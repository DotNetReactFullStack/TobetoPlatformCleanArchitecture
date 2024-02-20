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
using static Application.Features.AccountLearningPaths.Constants.AccountLearningPathsOperationClaims;

namespace Application.Features.AccountLearningPaths.Queries.GetListByAccountId;
public class GetListByAccountIdAccountLearningPathQuery : IRequest<GetListResponse<GetListByAccountIdAccountLearningPathListItemDto>>, ISecuredRequest, ICachableRequest
{
    public int? Id { get; set; }
    public int AccountId { get; set; }
    public PageRequest PageRequest { get; set; }
    public string[] Roles => new[] { Admin, Read, GeneralOperationClaims.Instructor, GeneralOperationClaims.Student };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListByAccountId({AccountId})AccountLearningPaths({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetAccountLearningPaths";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListByAccountIdAccountLearningPathQueryHandler : IRequestHandler<GetListByAccountIdAccountLearningPathQuery, GetListResponse<GetListByAccountIdAccountLearningPathListItemDto>>
    {
        private readonly IAccountLearningPathRepository _accountLearningPathRepository;
        private readonly IMapper _mapper;

        public GetListByAccountIdAccountLearningPathQueryHandler(IAccountLearningPathRepository accountLearningPathRepository, IMapper mapper)
        {
            _accountLearningPathRepository = accountLearningPathRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListByAccountIdAccountLearningPathListItemDto>> Handle(GetListByAccountIdAccountLearningPathQuery request, CancellationToken cancellationToken)
        {
            IPaginate<AccountLearningPath> accountLearningPaths = await _accountLearningPathRepository.GetListAsync(
                predicate: alp => alp.AccountId == request.AccountId,
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListByAccountIdAccountLearningPathListItemDto> response = _mapper.Map<GetListResponse<GetListByAccountIdAccountLearningPathListItemDto>>(accountLearningPaths);
            return response;
        }
    }

}

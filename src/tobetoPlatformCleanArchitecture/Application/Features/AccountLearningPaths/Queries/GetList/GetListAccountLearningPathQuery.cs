using Application.Features.AccountLearningPaths.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.AccountLearningPaths.Constants.AccountLearningPathsOperationClaims;

namespace Application.Features.AccountLearningPaths.Queries.GetList;

public class GetListAccountLearningPathQuery : IRequest<GetListResponse<GetListAccountLearningPathListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListAccountLearningPaths({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetAccountLearningPaths";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListAccountLearningPathQueryHandler : IRequestHandler<GetListAccountLearningPathQuery, GetListResponse<GetListAccountLearningPathListItemDto>>
    {
        private readonly IAccountLearningPathRepository _accountLearningPathRepository;
        private readonly IMapper _mapper;

        public GetListAccountLearningPathQueryHandler(IAccountLearningPathRepository accountLearningPathRepository, IMapper mapper)
        {
            _accountLearningPathRepository = accountLearningPathRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListAccountLearningPathListItemDto>> Handle(GetListAccountLearningPathQuery request, CancellationToken cancellationToken)
        {
            IPaginate<AccountLearningPath> accountLearningPaths = await _accountLearningPathRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListAccountLearningPathListItemDto> response = _mapper.Map<GetListResponse<GetListAccountLearningPathListItemDto>>(accountLearningPaths);
            return response;
        }
    }
}
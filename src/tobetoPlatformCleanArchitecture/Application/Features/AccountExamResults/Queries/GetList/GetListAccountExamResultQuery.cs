using Application.Features.AccountExamResults.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.AccountExamResults.Constants.AccountExamResultsOperationClaims;

namespace Application.Features.AccountExamResults.Queries.GetList;

public class GetListAccountExamResultQuery : IRequest<GetListResponse<GetListAccountExamResultListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListAccountExamResults({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetAccountExamResults";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListAccountExamResultQueryHandler : IRequestHandler<GetListAccountExamResultQuery, GetListResponse<GetListAccountExamResultListItemDto>>
    {
        private readonly IAccountExamResultRepository _accountExamResultRepository;
        private readonly IMapper _mapper;

        public GetListAccountExamResultQueryHandler(IAccountExamResultRepository accountExamResultRepository, IMapper mapper)
        {
            _accountExamResultRepository = accountExamResultRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListAccountExamResultListItemDto>> Handle(GetListAccountExamResultQuery request, CancellationToken cancellationToken)
        {
            IPaginate<AccountExamResult> accountExamResults = await _accountExamResultRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListAccountExamResultListItemDto> response = _mapper.Map<GetListResponse<GetListAccountExamResultListItemDto>>(accountExamResults);
            return response;
        }
    }
}
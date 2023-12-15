using Application.Features.AccountForeignLanguageMetadatas.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.AccountForeignLanguageMetadatas.Constants.AccountForeignLanguageMetadatasOperationClaims;

namespace Application.Features.AccountForeignLanguageMetadatas.Queries.GetList;

public class GetListAccountForeignLanguageMetadataQuery : IRequest<GetListResponse<GetListAccountForeignLanguageMetadataListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListAccountForeignLanguageMetadatas({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetAccountForeignLanguageMetadatas";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListAccountForeignLanguageMetadataQueryHandler : IRequestHandler<GetListAccountForeignLanguageMetadataQuery, GetListResponse<GetListAccountForeignLanguageMetadataListItemDto>>
    {
        private readonly IAccountForeignLanguageMetadataRepository _accountForeignLanguageMetadataRepository;
        private readonly IMapper _mapper;

        public GetListAccountForeignLanguageMetadataQueryHandler(IAccountForeignLanguageMetadataRepository accountForeignLanguageMetadataRepository, IMapper mapper)
        {
            _accountForeignLanguageMetadataRepository = accountForeignLanguageMetadataRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListAccountForeignLanguageMetadataListItemDto>> Handle(GetListAccountForeignLanguageMetadataQuery request, CancellationToken cancellationToken)
        {
            IPaginate<AccountForeignLanguageMetadata> accountForeignLanguageMetadatas = await _accountForeignLanguageMetadataRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListAccountForeignLanguageMetadataListItemDto> response = _mapper.Map<GetListResponse<GetListAccountForeignLanguageMetadataListItemDto>>(accountForeignLanguageMetadatas);
            return response;
        }
    }
}
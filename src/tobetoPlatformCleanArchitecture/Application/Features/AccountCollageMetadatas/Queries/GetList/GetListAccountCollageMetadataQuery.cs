using Application.Features.AccountCollageMetadatas.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.AccountCollageMetadatas.Constants.AccountCollageMetadatasOperationClaims;

namespace Application.Features.AccountCollageMetadatas.Queries.GetList;

public class GetListAccountCollageMetadataQuery : IRequest<GetListResponse<GetListAccountCollageMetadataListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListAccountCollageMetadatas({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetAccountCollageMetadatas";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListAccountCollageMetadataQueryHandler : IRequestHandler<GetListAccountCollageMetadataQuery, GetListResponse<GetListAccountCollageMetadataListItemDto>>
    {
        private readonly IAccountCollageMetadataRepository _accountCollageMetadataRepository;
        private readonly IMapper _mapper;

        public GetListAccountCollageMetadataQueryHandler(IAccountCollageMetadataRepository accountCollageMetadataRepository, IMapper mapper)
        {
            _accountCollageMetadataRepository = accountCollageMetadataRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListAccountCollageMetadataListItemDto>> Handle(GetListAccountCollageMetadataQuery request, CancellationToken cancellationToken)
        {
            IPaginate<AccountCollageMetadata> accountCollageMetadatas = await _accountCollageMetadataRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListAccountCollageMetadataListItemDto> response = _mapper.Map<GetListResponse<GetListAccountCollageMetadataListItemDto>>(accountCollageMetadatas);
            return response;
        }
    }
}
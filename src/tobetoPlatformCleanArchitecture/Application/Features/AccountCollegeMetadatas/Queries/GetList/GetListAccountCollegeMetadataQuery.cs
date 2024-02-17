using Application.Features.AccountCollegeMetadatas.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.AccountCollegeMetadatas.Constants.AccountCollegeMetadatasOperationClaims;

namespace Application.Features.AccountCollegeMetadatas.Queries.GetList;

public class GetListAccountCollegeMetadataQuery : IRequest<GetListResponse<GetListAccountCollegeMetadataListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListAccountCollegeMetadatas({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetAccountCollegeMetadatas";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListAccountCollegeMetadataQueryHandler : IRequestHandler<GetListAccountCollegeMetadataQuery, GetListResponse<GetListAccountCollegeMetadataListItemDto>>
    {
        private readonly IAccountCollegeMetadataRepository _accountCollegeMetadataRepository;
        private readonly IMapper _mapper;

        public GetListAccountCollegeMetadataQueryHandler(IAccountCollegeMetadataRepository accountCollegeMetadataRepository, IMapper mapper)
        {
            _accountCollegeMetadataRepository = accountCollegeMetadataRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListAccountCollegeMetadataListItemDto>> Handle(GetListAccountCollegeMetadataQuery request, CancellationToken cancellationToken)
        {
            IPaginate<AccountCollegeMetadata> accountCollegeMetadatas = await _accountCollegeMetadataRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListAccountCollegeMetadataListItemDto> response = _mapper.Map<GetListResponse<GetListAccountCollegeMetadataListItemDto>>(accountCollegeMetadatas);
            return response;
        }
    }
}
using Application.Features.AccountCapabilities.Queries.GetListByAccountId;
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.Features.AccountForeignLanguageMetadatas.Constants.AccountForeignLanguageMetadatasOperationClaims;

namespace Application.Features.AccountForeignLanguageMetadatas.Queries.GetListByAccountId;
public class GetListByAccountIdAccountForeingLanguageMetaDataQuery : IRequest<GetListResponse<GetListByAccountIdAccountForeingLanguageMetaDataItemDto>>, ISecuredRequest, ICachableRequest
{
    public int? Id { get; set; }
    public int AccountId { get; set; }
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read, GeneralOperationClaims.Instructor, GeneralOperationClaims.Student };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListByAccountId({AccountId})AccountForeingLanguageMetaData({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetAccountForeignLanguageMetadatas";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListByAccountIdAccountForeingLanguageMetaDataQueryHandler : IRequestHandler<GetListByAccountIdAccountForeingLanguageMetaDataQuery, GetListResponse<GetListByAccountIdAccountForeingLanguageMetaDataItemDto>>
    {
        private readonly IAccountForeignLanguageMetadataRepository _accountForeignLanguageMetadataRepository;
        private readonly IMapper _mapper;

        public GetListByAccountIdAccountForeingLanguageMetaDataQueryHandler(IAccountForeignLanguageMetadataRepository accountForeignLanguageMetadataRepository, IMapper mapper)
        {
            _accountForeignLanguageMetadataRepository = accountForeignLanguageMetadataRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListByAccountIdAccountForeingLanguageMetaDataItemDto>> Handle(GetListByAccountIdAccountForeingLanguageMetaDataQuery request, CancellationToken cancellationToken)
        {
            IPaginate<AccountForeignLanguageMetadata> accountForeignLanguageMetadata = await _accountForeignLanguageMetadataRepository.GetListAsync(
                predicate: (ac => ac.AccountId == request.AccountId),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken,
                include: ac => ac.Include(p => p.ForeignLanguageLevel).Include(p => p.ForeignLanguage)         
            );

            GetListResponse<GetListByAccountIdAccountForeingLanguageMetaDataItemDto> response = _mapper.Map<GetListResponse<GetListByAccountIdAccountForeingLanguageMetaDataItemDto>>(accountForeignLanguageMetadata);
            return response;
        }
    }
}

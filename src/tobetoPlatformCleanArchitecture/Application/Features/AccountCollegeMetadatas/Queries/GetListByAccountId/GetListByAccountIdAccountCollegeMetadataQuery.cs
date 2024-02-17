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
using static Application.Features.AccountCapabilities.Constants.AccountCapabilitiesOperationClaims;

namespace Application.Features.AccountCollegeMetadatas.Queries.GetListByAccountId;
public class GetListByAccountIdAccountCollegeMetadataQuery : IRequest<GetListResponse<GetListByAccountIdAccountCollegeMetadataListItemDto>>, ISecuredRequest, ICachableRequest
{
    public int? Id { get; set; }
    public int AccountId { get; set; }
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read, GeneralOperationClaims.Instructor, GeneralOperationClaims.Student };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListByAccountId({AccountId}AccountCollegeMetadatas({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetAccountCollegeMetadatas";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListByAccountIdAccountCollegeMetadataQueryHandler : IRequestHandler<GetListByAccountIdAccountCollegeMetadataQuery, GetListResponse<GetListByAccountIdAccountCollegeMetadataListItemDto>>
    {
        private readonly IAccountCollegeMetadataRepository _accountCollegeMetadataRepository;
        private readonly IMapper _mapper;

        public GetListByAccountIdAccountCollegeMetadataQueryHandler(IAccountCollegeMetadataRepository accountCollegeMetadataRepository, IMapper mapper)
        {
            _accountCollegeMetadataRepository = accountCollegeMetadataRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListByAccountIdAccountCollegeMetadataListItemDto>> Handle(GetListByAccountIdAccountCollegeMetadataQuery request, CancellationToken cancellationToken)
        {
            IPaginate<AccountCollegeMetadata> accountCollegeMetadatas = await _accountCollegeMetadataRepository.GetListAsync(
                predicate: acm => acm.AccountId == request.AccountId,
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken,
                include: acm => acm.Include(acm => acm.GraduationStatus)
                .Include(acm => acm.College)
                .Include(acm => acm.EducationProgram)
            );

            GetListResponse<GetListByAccountIdAccountCollegeMetadataListItemDto> response = _mapper.Map<GetListResponse<GetListByAccountIdAccountCollegeMetadataListItemDto>>(accountCollegeMetadatas);
            return response;
        }
    }



}

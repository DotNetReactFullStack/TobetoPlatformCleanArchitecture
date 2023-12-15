using Application.Features.AccountCertificates.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.AccountCertificates.Constants.AccountCertificatesOperationClaims;

namespace Application.Features.AccountCertificates.Queries.GetList;

public class GetListAccountCertificateQuery : IRequest<GetListResponse<GetListAccountCertificateListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListAccountCertificates({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetAccountCertificates";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListAccountCertificateQueryHandler : IRequestHandler<GetListAccountCertificateQuery, GetListResponse<GetListAccountCertificateListItemDto>>
    {
        private readonly IAccountCertificateRepository _accountCertificateRepository;
        private readonly IMapper _mapper;

        public GetListAccountCertificateQueryHandler(IAccountCertificateRepository accountCertificateRepository, IMapper mapper)
        {
            _accountCertificateRepository = accountCertificateRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListAccountCertificateListItemDto>> Handle(GetListAccountCertificateQuery request, CancellationToken cancellationToken)
        {
            IPaginate<AccountCertificate> accountCertificates = await _accountCertificateRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListAccountCertificateListItemDto> response = _mapper.Map<GetListResponse<GetListAccountCertificateListItemDto>>(accountCertificates);
            return response;
        }
    }
}
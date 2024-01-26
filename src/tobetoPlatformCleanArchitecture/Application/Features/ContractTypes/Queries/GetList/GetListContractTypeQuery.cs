using Application.Features.ContractTypes.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.ContractTypes.Constants.ContractTypesOperationClaims;

namespace Application.Features.ContractTypes.Queries.GetList;

public class GetListContractTypeQuery : IRequest<GetListResponse<GetListContractTypeListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListContractTypes({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetContractTypes";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListContractTypeQueryHandler : IRequestHandler<GetListContractTypeQuery, GetListResponse<GetListContractTypeListItemDto>>
    {
        private readonly IContractTypeRepository _contractTypeRepository;
        private readonly IMapper _mapper;

        public GetListContractTypeQueryHandler(IContractTypeRepository contractTypeRepository, IMapper mapper)
        {
            _contractTypeRepository = contractTypeRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListContractTypeListItemDto>> Handle(GetListContractTypeQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ContractType> contractTypes = await _contractTypeRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListContractTypeListItemDto> response = _mapper.Map<GetListResponse<GetListContractTypeListItemDto>>(contractTypes);
            return response;
        }
    }
}
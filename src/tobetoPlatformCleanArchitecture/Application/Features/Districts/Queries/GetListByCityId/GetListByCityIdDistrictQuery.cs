using Application.Features.Cities.Queries.GetListByCountryId;
using Application.Features.OperationClaims.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.Features.Districts.Constants.DistrictsOperationClaims;

namespace Application.Features.Districts.Queries.GetListByCityId;
public class GetListByCityIdDistrictQuery : IRequest<GetListResponse<GetListByCityIdDistrictListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }
    public int CityId { get; set; }

    public string[] Roles => new[] { Admin, Read, GeneralOperationClaims.Instructor, GeneralOperationClaims.Student };

    public class GetListByCityIdDistrictQueryHandler : IRequestHandler<GetListByCityIdDistrictQuery, GetListResponse<GetListByCityIdDistrictListItemDto>>
    {
        private readonly IDistrictRepository _districtRepository;
        private readonly IMapper _mapper;

        public GetListByCityIdDistrictQueryHandler(IDistrictRepository districtRepository, IMapper mapper)
        {
            _districtRepository = districtRepository;
            _mapper = mapper;
        }
        public async Task<GetListResponse<GetListByCityIdDistrictListItemDto>> Handle(GetListByCityIdDistrictQuery request, CancellationToken cancellationToken)
        {
            IPaginate<District> districts = await _districtRepository.GetListAsync(
                predicate: ep => ep.CityId == request.CityId,
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListByCityIdDistrictListItemDto> response = _mapper.Map<GetListResponse<GetListByCityIdDistrictListItemDto>>(districts);
            return response;
        }


    }
}

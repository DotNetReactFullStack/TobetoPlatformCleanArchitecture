using Application.Features.EducationPrograms.Queries.GetListByCollegeId;
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Application.Features.Cities.Constants.CitiesOperationClaims;

namespace Application.Features.Cities.Queries.GetListByCountryId;
public class GetListByCountryIdCityQuery : IRequest<GetListResponse<GetListByCountryIdCityListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }
    public int CountryId { get; set; }

    public string[] Roles => new[] { Admin, Read, GeneralOperationClaims.Instructor, GeneralOperationClaims.Student };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListByCountryId({CountryId})Cities({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetCities";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListByCountryIdCityQueryHandler : IRequestHandler<GetListByCountryIdCityQuery, GetListResponse<GetListByCountryIdCityListItemDto>>
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public GetListByCountryIdCityQueryHandler(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }
        public async Task<GetListResponse<GetListByCountryIdCityListItemDto>> Handle(GetListByCountryIdCityQuery request, CancellationToken cancellationToken)
        {
            IPaginate<City> cities = await _cityRepository.GetListAsync(
                predicate: ep => ep.CountryId == request.CountryId,
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListByCountryIdCityListItemDto> response = _mapper.Map<GetListResponse<GetListByCountryIdCityListItemDto>>(cities);
            return response;
        }

       
    }
}

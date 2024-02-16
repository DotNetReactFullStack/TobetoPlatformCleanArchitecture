using Application.Features.Cities.Commands.Create;
using Application.Features.Cities.Commands.Delete;
using Application.Features.Cities.Commands.Update;
using Application.Features.Cities.Queries.GetById;
using Application.Features.Cities.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;
using Application.Features.EducationPrograms.Queries.GetList;
using Application.Features.EducationPrograms.Queries.GetListByCollegeId;
using Application.Features.Cities.Queries.GetListByCountryId;

namespace Application.Features.Cities.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<City, CreateCityCommand>().ReverseMap();
        CreateMap<City, CreatedCityResponse>().ReverseMap();
        CreateMap<City, UpdateCityCommand>().ReverseMap();
        CreateMap<City, UpdatedCityResponse>().ReverseMap();
        CreateMap<City, DeleteCityCommand>().ReverseMap();
        CreateMap<City, DeletedCityResponse>().ReverseMap();
        CreateMap<City, GetByIdCityResponse>().ReverseMap();
        CreateMap<City, GetListCityListItemDto>().ReverseMap();
        CreateMap<IPaginate<City>, GetListResponse<GetListCityListItemDto>>().ReverseMap();
        CreateMap<City, GetListByCountryIdCityListItemDto>().ReverseMap();
        CreateMap<IPaginate<City>, GetListResponse<GetListByCountryIdCityListItemDto>>().ReverseMap();
        
    }
}
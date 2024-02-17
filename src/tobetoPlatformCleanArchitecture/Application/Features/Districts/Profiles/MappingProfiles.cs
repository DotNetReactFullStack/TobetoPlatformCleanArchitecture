using Application.Features.Districts.Commands.Create;
using Application.Features.Districts.Commands.Delete;
using Application.Features.Districts.Commands.Update;
using Application.Features.Districts.Queries.GetById;
using Application.Features.Districts.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;
using Application.Features.Cities.Queries.GetListByCountryId;
using Application.Features.Districts.Queries.GetListByCityId;

namespace Application.Features.Districts.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<District, CreateDistrictCommand>().ReverseMap();
        CreateMap<District, CreatedDistrictResponse>().ReverseMap();
        CreateMap<District, UpdateDistrictCommand>().ReverseMap();
        CreateMap<District, UpdatedDistrictResponse>().ReverseMap();
        CreateMap<District, DeleteDistrictCommand>().ReverseMap();
        CreateMap<District, DeletedDistrictResponse>().ReverseMap();
        CreateMap<District, GetByIdDistrictResponse>().ReverseMap();
        CreateMap<District, GetListDistrictListItemDto>().ReverseMap();
        //CreateMap<District, GetListByCityIdDistrictListItemDto>().ReverseMap();
        CreateMap<IPaginate<District>, GetListResponse<GetListDistrictListItemDto>>().ReverseMap();

        CreateMap<District, GetListByCityIdDistrictListItemDto>().
            ForMember(destinationMember: d => d.DistrictName,
            memberOptions: opt => opt.MapFrom(d => d.Name)).ReverseMap();
        CreateMap<IPaginate<District>, GetListResponse<GetListByCityIdDistrictListItemDto>>().ReverseMap();
    }
}
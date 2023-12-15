using Application.Features.Countries.Commands.Create;
using Application.Features.Countries.Commands.Delete;
using Application.Features.Countries.Commands.Update;
using Application.Features.Countries.Queries.GetById;
using Application.Features.Countries.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.Countries.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Country, CreateCountryCommand>().ReverseMap();
        CreateMap<Country, CreatedCountryResponse>().ReverseMap();
        CreateMap<Country, UpdateCountryCommand>().ReverseMap();
        CreateMap<Country, UpdatedCountryResponse>().ReverseMap();
        CreateMap<Country, DeleteCountryCommand>().ReverseMap();
        CreateMap<Country, DeletedCountryResponse>().ReverseMap();
        CreateMap<Country, GetByIdCountryResponse>().ReverseMap();
        CreateMap<Country, GetListCountryListItemDto>().ReverseMap();
        CreateMap<IPaginate<Country>, GetListResponse<GetListCountryListItemDto>>().ReverseMap();
    }
}
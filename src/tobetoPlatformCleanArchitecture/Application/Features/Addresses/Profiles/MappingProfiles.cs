using Application.Features.Addresses.Commands.Create;
using Application.Features.Addresses.Commands.Delete;
using Application.Features.Addresses.Commands.Update;
using Application.Features.Addresses.Queries.GetById;
using Application.Features.Addresses.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.Addresses.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Address, CreateAddressCommand>().ReverseMap();
        CreateMap<Address, CreatedAddressResponse>().ReverseMap();
        CreateMap<Address, UpdateAddressCommand>().ReverseMap();
        CreateMap<Address, UpdatedAddressResponse>().ReverseMap();
        CreateMap<Address, DeleteAddressCommand>().ReverseMap();
        CreateMap<Address, DeletedAddressResponse>().ReverseMap();
        CreateMap<Address, GetByIdAddressResponse>().ReverseMap();
        CreateMap<Address, GetListAddressListItemDto>().ReverseMap();
        CreateMap<IPaginate<Address>, GetListResponse<GetListAddressListItemDto>>().ReverseMap();
    }
}
using Application.Features.AccountCapabilities.Commands.Create;
using Application.Features.AccountCapabilities.Commands.Delete;
using Application.Features.AccountCapabilities.Commands.Update;
using Application.Features.AccountCapabilities.Queries.GetById;
using Application.Features.AccountCapabilities.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;
using Application.Features.AccountCapabilities.Queries.GetListByAccountId;

namespace Application.Features.AccountCapabilities.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<AccountCapability, CreateAccountCapabilityCommand>().ReverseMap();
        CreateMap<AccountCapability, CreatedAccountCapabilityResponse>().ReverseMap();
        CreateMap<AccountCapability, UpdateAccountCapabilityCommand>().ReverseMap();
        CreateMap<AccountCapability, UpdatedAccountCapabilityResponse>().ReverseMap();
        CreateMap<AccountCapability, DeleteAccountCapabilityCommand>().ReverseMap();
        CreateMap<AccountCapability, DeletedAccountCapabilityResponse>().ReverseMap();
        CreateMap<AccountCapability, GetByIdAccountCapabilityResponse>().ReverseMap();
        CreateMap<AccountCapability, GetListAccountCapabilityListItemDto>().ReverseMap();
        CreateMap<AccountCapability, GetListByAccountIdAccountCapabilityListItemDto>()
            .ForMember(destinationMember: d=>d.CapabilityName,
            memberOptions: opt=>opt.MapFrom(ac=>ac.Capability.Name))
           //.ForMember(destinationMember: d => d.CapabilityName,
           // memberOptions: opt => opt.MapFrom(ac => ac.Capability.Name))
            .ReverseMap();
        CreateMap<IPaginate<AccountCapability>, GetListResponse<GetListAccountCapabilityListItemDto>>().ReverseMap();
        CreateMap<IPaginate<AccountCapability>, GetListResponse<GetListByAccountIdAccountCapabilityListItemDto>>().ReverseMap();
    }
}
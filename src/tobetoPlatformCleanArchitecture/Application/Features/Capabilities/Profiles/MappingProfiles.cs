using Application.Features.Capabilities.Commands.Create;
using Application.Features.Capabilities.Commands.Delete;
using Application.Features.Capabilities.Commands.Update;
using Application.Features.Capabilities.Queries.GetById;
using Application.Features.Capabilities.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.Capabilities.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Capability, CreateCapabilityCommand>().ReverseMap();
        CreateMap<Capability, CreatedCapabilityResponse>().ReverseMap();
        CreateMap<Capability, UpdateCapabilityCommand>().ReverseMap();
        CreateMap<Capability, UpdatedCapabilityResponse>().ReverseMap();
        CreateMap<Capability, DeleteCapabilityCommand>().ReverseMap();
        CreateMap<Capability, DeletedCapabilityResponse>().ReverseMap();
        CreateMap<Capability, GetByIdCapabilityResponse>().ReverseMap();
        CreateMap<Capability, GetListCapabilityListItemDto>().ReverseMap();
        CreateMap<IPaginate<Capability>, GetListResponse<GetListCapabilityListItemDto>>().ReverseMap();
    }
}
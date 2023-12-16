using Application.Features.OrganizationTypes.Commands.Create;
using Application.Features.OrganizationTypes.Commands.Delete;
using Application.Features.OrganizationTypes.Commands.Update;
using Application.Features.OrganizationTypes.Queries.GetById;
using Application.Features.OrganizationTypes.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.OrganizationTypes.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<OrganizationType, CreateOrganizationTypeCommand>().ReverseMap();
        CreateMap<OrganizationType, CreatedOrganizationTypeResponse>().ReverseMap();
        CreateMap<OrganizationType, UpdateOrganizationTypeCommand>().ReverseMap();
        CreateMap<OrganizationType, UpdatedOrganizationTypeResponse>().ReverseMap();
        CreateMap<OrganizationType, DeleteOrganizationTypeCommand>().ReverseMap();
        CreateMap<OrganizationType, DeletedOrganizationTypeResponse>().ReverseMap();
        CreateMap<OrganizationType, GetByIdOrganizationTypeResponse>().ReverseMap();
        CreateMap<OrganizationType, GetListOrganizationTypeListItemDto>().ReverseMap();
        CreateMap<IPaginate<OrganizationType>, GetListResponse<GetListOrganizationTypeListItemDto>>().ReverseMap();
    }
}
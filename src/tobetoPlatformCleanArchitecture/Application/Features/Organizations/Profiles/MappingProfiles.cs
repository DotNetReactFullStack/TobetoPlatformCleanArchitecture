using Application.Features.Organizations.Commands.Create;
using Application.Features.Organizations.Commands.Delete;
using Application.Features.Organizations.Commands.Update;
using Application.Features.Organizations.Queries.GetById;
using Application.Features.Organizations.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.Organizations.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Organization, CreateOrganizationCommand>().ReverseMap();
        CreateMap<Organization, CreatedOrganizationResponse>().ReverseMap();
        CreateMap<Organization, UpdateOrganizationCommand>().ReverseMap();
        CreateMap<Organization, UpdatedOrganizationResponse>().ReverseMap();
        CreateMap<Organization, DeleteOrganizationCommand>().ReverseMap();
        CreateMap<Organization, DeletedOrganizationResponse>().ReverseMap();
        CreateMap<Organization, GetByIdOrganizationResponse>().ReverseMap();
        CreateMap<Organization, GetListOrganizationListItemDto>().ReverseMap();
        CreateMap<IPaginate<Organization>, GetListResponse<GetListOrganizationListItemDto>>().ReverseMap();
    }
}
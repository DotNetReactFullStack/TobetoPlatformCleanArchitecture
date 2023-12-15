using Application.Features.GraduationStatuses.Commands.Create;
using Application.Features.GraduationStatuses.Commands.Delete;
using Application.Features.GraduationStatuses.Commands.Update;
using Application.Features.GraduationStatuses.Queries.GetById;
using Application.Features.GraduationStatuses.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.GraduationStatuses.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<GraduationStatus, CreateGraduationStatusCommand>().ReverseMap();
        CreateMap<GraduationStatus, CreatedGraduationStatusResponse>().ReverseMap();
        CreateMap<GraduationStatus, UpdateGraduationStatusCommand>().ReverseMap();
        CreateMap<GraduationStatus, UpdatedGraduationStatusResponse>().ReverseMap();
        CreateMap<GraduationStatus, DeleteGraduationStatusCommand>().ReverseMap();
        CreateMap<GraduationStatus, DeletedGraduationStatusResponse>().ReverseMap();
        CreateMap<GraduationStatus, GetByIdGraduationStatusResponse>().ReverseMap();
        CreateMap<GraduationStatus, GetListGraduationStatusListItemDto>().ReverseMap();
        CreateMap<IPaginate<GraduationStatus>, GetListResponse<GetListGraduationStatusListItemDto>>().ReverseMap();
    }
}
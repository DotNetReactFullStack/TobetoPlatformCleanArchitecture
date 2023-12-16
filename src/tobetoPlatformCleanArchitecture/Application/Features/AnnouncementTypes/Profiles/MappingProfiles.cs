using Application.Features.AnnouncementTypes.Commands.Create;
using Application.Features.AnnouncementTypes.Commands.Delete;
using Application.Features.AnnouncementTypes.Commands.Update;
using Application.Features.AnnouncementTypes.Queries.GetById;
using Application.Features.AnnouncementTypes.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.AnnouncementTypes.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<AnnouncementType, CreateAnnouncementTypeCommand>().ReverseMap();
        CreateMap<AnnouncementType, CreatedAnnouncementTypeResponse>().ReverseMap();
        CreateMap<AnnouncementType, UpdateAnnouncementTypeCommand>().ReverseMap();
        CreateMap<AnnouncementType, UpdatedAnnouncementTypeResponse>().ReverseMap();
        CreateMap<AnnouncementType, DeleteAnnouncementTypeCommand>().ReverseMap();
        CreateMap<AnnouncementType, DeletedAnnouncementTypeResponse>().ReverseMap();
        CreateMap<AnnouncementType, GetByIdAnnouncementTypeResponse>().ReverseMap();
        CreateMap<AnnouncementType, GetListAnnouncementTypeListItemDto>().ReverseMap();
        CreateMap<IPaginate<AnnouncementType>, GetListResponse<GetListAnnouncementTypeListItemDto>>().ReverseMap();
    }
}
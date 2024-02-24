using Application.Features.AccountAnnouncements.Commands.Create;
using Application.Features.AccountAnnouncements.Commands.Delete;
using Application.Features.AccountAnnouncements.Commands.Update;
using Application.Features.AccountAnnouncements.Queries.GetById;
using Application.Features.AccountAnnouncements.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;
using Application.Features.AccountAnnouncements.Queries.GetListByAccountId;

namespace Application.Features.AccountAnnouncements.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<AccountAnnouncement, CreateAccountAnnouncementCommand>().ReverseMap();
        CreateMap<AccountAnnouncement, CreatedAccountAnnouncementResponse>().ReverseMap();
        CreateMap<AccountAnnouncement, UpdateAccountAnnouncementCommand>().ReverseMap();
        CreateMap<AccountAnnouncement, UpdatedAccountAnnouncementResponse>().ReverseMap();
        CreateMap<AccountAnnouncement, DeleteAccountAnnouncementCommand>().ReverseMap();
        CreateMap<AccountAnnouncement, DeletedAccountAnnouncementResponse>().ReverseMap();
        CreateMap<AccountAnnouncement, GetByIdAccountAnnouncementResponse>().ReverseMap();
        CreateMap<AccountAnnouncement, GetListAccountAnnouncementListItemDto>().ReverseMap();
        CreateMap<AccountAnnouncement, GetListByAccountIdAccountAnnouncementListItemDto>()
            .ForMember(destinationMember: dest => dest.AnnouncementTypeName, memberOptions: opt => opt.MapFrom(src => src.Announcement.AnnouncementType.Name))
            .ForMember(destinationMember: dest => dest.OrganizationName, memberOptions: opt => opt.MapFrom(src => src.Announcement.Organization.Name))
            .ForMember(destinationMember: dest => dest.Name, memberOptions: opt => opt.MapFrom(src => src.Announcement.Name))
            .ForMember(destinationMember: dest => dest.Content, memberOptions: opt => opt.MapFrom(src => src.Announcement.Content))
            .ForMember(destinationMember: dest => dest.PublishedDate, memberOptions: opt => opt.MapFrom(src => src.Announcement.PublishedDate))
            .ForMember(destinationMember: dest => dest.Read, memberOptions: opt=>opt.MapFrom(src => src.Announcement.AccountAnnouncements.FirstOrDefault().Read))
            .ForMember(destinationMember: dest=>dest.Priority, memberOptions: opt=>opt.MapFrom(src=>src.Announcement.Priority))
            .ForMember(destinationMember: dest=>dest.Visibility, memberOptions: opt=>opt.MapFrom(src=>src.Announcement.Visibility))
            .ReverseMap();
        CreateMap<IPaginate<AccountAnnouncement>, GetListResponse<GetListAccountAnnouncementListItemDto>>().ReverseMap();
        CreateMap<IPaginate<AccountAnnouncement>, GetListResponse<GetListByAccountIdAccountAnnouncementListItemDto>>().ReverseMap();
    }
}
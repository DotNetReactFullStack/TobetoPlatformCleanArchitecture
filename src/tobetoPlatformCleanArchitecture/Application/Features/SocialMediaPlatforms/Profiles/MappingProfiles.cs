using Application.Features.SocialMediaPlatforms.Commands.Create;
using Application.Features.SocialMediaPlatforms.Commands.Delete;
using Application.Features.SocialMediaPlatforms.Commands.Update;
using Application.Features.SocialMediaPlatforms.Queries.GetById;
using Application.Features.SocialMediaPlatforms.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.SocialMediaPlatforms.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<SocialMediaPlatform, CreateSocialMediaPlatformCommand>().ReverseMap();
        CreateMap<SocialMediaPlatform, CreatedSocialMediaPlatformResponse>().ReverseMap();
        CreateMap<SocialMediaPlatform, UpdateSocialMediaPlatformCommand>().ReverseMap();
        CreateMap<SocialMediaPlatform, UpdatedSocialMediaPlatformResponse>().ReverseMap();
        CreateMap<SocialMediaPlatform, DeleteSocialMediaPlatformCommand>().ReverseMap();
        CreateMap<SocialMediaPlatform, DeletedSocialMediaPlatformResponse>().ReverseMap();
        CreateMap<SocialMediaPlatform, GetByIdSocialMediaPlatformResponse>().ReverseMap();
        CreateMap<SocialMediaPlatform, GetListSocialMediaPlatformListItemDto>().ReverseMap();
        CreateMap<IPaginate<SocialMediaPlatform>, GetListResponse<GetListSocialMediaPlatformListItemDto>>().ReverseMap();
    }
}
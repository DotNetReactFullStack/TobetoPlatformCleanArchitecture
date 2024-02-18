using Application.Features.AccountSocialMediaPlatforms.Commands.Create;
using Application.Features.AccountSocialMediaPlatforms.Commands.Delete;
using Application.Features.AccountSocialMediaPlatforms.Commands.Update;
using Application.Features.AccountSocialMediaPlatforms.Queries.GetById;
using Application.Features.AccountSocialMediaPlatforms.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;
using Application.Features.AccountSocialMediaPlatforms.Queries.GetListByAccountId;

namespace Application.Features.AccountSocialMediaPlatforms.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<AccountSocialMediaPlatform, CreateAccountSocialMediaPlatformCommand>().ReverseMap();
        CreateMap<AccountSocialMediaPlatform, CreatedAccountSocialMediaPlatformResponse>().ReverseMap();
        CreateMap<AccountSocialMediaPlatform, UpdateAccountSocialMediaPlatformCommand>().ReverseMap();
        CreateMap<AccountSocialMediaPlatform, UpdatedAccountSocialMediaPlatformResponse>().ReverseMap();
        CreateMap<AccountSocialMediaPlatform, DeleteAccountSocialMediaPlatformCommand>().ReverseMap();
        CreateMap<AccountSocialMediaPlatform, DeletedAccountSocialMediaPlatformResponse>().ReverseMap();
        CreateMap<AccountSocialMediaPlatform, GetByIdAccountSocialMediaPlatformResponse>().ReverseMap();
        CreateMap<AccountSocialMediaPlatform, GetListAccountSocialMediaPlatformListItemDto>().ReverseMap();
        CreateMap<AccountSocialMediaPlatform, GetListByAccountIdAccountSocialMediaPlatformsItemDto>()
            .ForMember(destinationMember: d => d.Name,
            memberOptions: opt => opt.MapFrom(sm => sm.SocialMediaPlatform.Name))
            .ForMember(destinationMember: d => d.IconPath, 
            memberOptions: opt => opt.MapFrom(sm=>sm.SocialMediaPlatform.IconPath))
            .ReverseMap();




        CreateMap<IPaginate<AccountSocialMediaPlatform>, GetListResponse<GetListAccountSocialMediaPlatformListItemDto>>().ReverseMap();
        CreateMap<IPaginate<AccountSocialMediaPlatform>, GetListResponse<GetListByAccountIdAccountSocialMediaPlatformsItemDto>>().ReverseMap();
    }
}
using Application.Features.AccountLearningPaths.Commands.Create;
using Application.Features.AccountLearningPaths.Commands.Delete;
using Application.Features.AccountLearningPaths.Commands.Update;
using Application.Features.AccountLearningPaths.Queries.GetById;
using Application.Features.AccountLearningPaths.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;
using Application.Features.AccountLearningPaths.Queries.GetListByAccountId;
using Application.Features.AccountLearningPaths.Queries.GetListByLearningPathId;
using Application.Features.AccountLearningPaths.Commands.Update.UpdateAccountLearningPathIsLiked;
using Application.Features.AccountLearningPaths.Commands.Update.UpdateAccountLearningPathIsSaved;
using Application.Features.AccountLearningPaths.Commands.Update.UpdateAccountLearningPathPercentComplete;

namespace Application.Features.AccountLearningPaths.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {        
        CreateMap<AccountLearningPath, CreateAccountLearningPathCommand>().ReverseMap();
        CreateMap<AccountLearningPath, CreatedAccountLearningPathResponse>().ReverseMap();
        CreateMap<AccountLearningPath, UpdateAccountLearningPathCommand>().ReverseMap();
        CreateMap<AccountLearningPath, UpdatedAccountLearningPathResponse>().ReverseMap();
        CreateMap<AccountLearningPath, UpdateAccountLearningPathIsLikedCommand>().ReverseMap();
        CreateMap<AccountLearningPath, UpdateAccountLearningPathIsSavedCommand>().ReverseMap();
        CreateMap<AccountLearningPath, UpdateAccountLearningPathPercentCompleteCommand>().ReverseMap();
        CreateMap<AccountLearningPath, DeleteAccountLearningPathCommand>().ReverseMap();
        CreateMap<AccountLearningPath, DeletedAccountLearningPathResponse>().ReverseMap();
        CreateMap<AccountLearningPath, GetByIdAccountLearningPathResponse>().ReverseMap();
        CreateMap<AccountLearningPath, GetByAccountIdAndLearningPathIdAccountLearningPathResponse>()
           .ForMember(destinationMember: d => d.LearningPathCategoryId,
           memberOptions: opt => opt.MapFrom(alp => alp.LearningPath.LearningPathCategoryId))
           .ForMember(destinationMember: d => d.LearningPathName,
           memberOptions: opt => opt.MapFrom(alp => alp.LearningPath.Name))
           .ForMember(destinationMember: d => d.Visibility,
           memberOptions: opt => opt.MapFrom(alp => alp.LearningPath.Visibility))
           .ForMember(destinationMember: d => d.StartingTime,
           memberOptions: opt => opt.MapFrom(alp => alp.LearningPath.StartingTime))
           .ForMember(destinationMember: d => d.EndingTime,
           memberOptions: opt => opt.MapFrom(alp => alp.LearningPath.EndingTime))
           .ForMember(destinationMember: d => d.NumberOfLikes,
           memberOptions: opt => opt.MapFrom(alp => alp.LearningPath.NumberOfLikes))
           .ForMember(destinationMember: d => d.TotalDuration,
           memberOptions: opt => opt.MapFrom(alp => alp.LearningPath.TotalDuration))
           .ForMember(destinationMember: d => d.ImageUrl,
           memberOptions: opt => opt.MapFrom(alp => alp.LearningPath.ImageUrl))
           .ReverseMap();
        CreateMap<AccountLearningPath, GetListAccountLearningPathListItemDto>().ReverseMap();
        CreateMap<AccountLearningPath, GetListByAccountIdAccountLearningPathListItemDto>()
            .ForMember(destinationMember: d => d.LearningPathCategoryId,
            memberOptions: opt => opt.MapFrom(alp => alp.LearningPath.LearningPathCategoryId))
            .ForMember(destinationMember: d => d.LearningPathName,
            memberOptions: opt => opt.MapFrom(alp => alp.LearningPath.Name))
            .ForMember(destinationMember: d => d.Visibility,
            memberOptions: opt => opt.MapFrom(alp => alp.LearningPath.Visibility))
            .ForMember(destinationMember: d => d.StartingTime,
            memberOptions: opt => opt.MapFrom(alp => alp.LearningPath.StartingTime))
            .ForMember(destinationMember: d => d.EndingTime,
            memberOptions: opt => opt.MapFrom(alp => alp.LearningPath.EndingTime))
            .ForMember(destinationMember: d => d.NumberOfLikes,
            memberOptions: opt => opt.MapFrom(alp => alp.LearningPath.NumberOfLikes))
            .ForMember(destinationMember: d => d.TotalDuration,
            memberOptions: opt => opt.MapFrom(alp => alp.LearningPath.TotalDuration))
            .ForMember(destinationMember: d => d.ImageUrl,
            memberOptions: opt => opt.MapFrom(alp => alp.LearningPath.ImageUrl))
            .ReverseMap();

        CreateMap<AccountLearningPath, GetListByLearningPathIdAccountLearningPathListItemDto>().ReverseMap();
        CreateMap<IPaginate<AccountLearningPath>, GetListResponse<GetListAccountLearningPathListItemDto>>().ReverseMap();
        CreateMap<IPaginate<AccountLearningPath>, GetListResponse<GetListByAccountIdAccountLearningPathListItemDto>>().ReverseMap();  
        CreateMap<IPaginate<AccountLearningPath>, GetListResponse<GetListByLearningPathIdAccountLearningPathListItemDto>>().ReverseMap();

    }
}
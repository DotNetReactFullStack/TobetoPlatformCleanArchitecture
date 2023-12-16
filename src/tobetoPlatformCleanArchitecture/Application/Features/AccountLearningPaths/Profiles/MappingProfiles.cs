using Application.Features.AccountLearningPaths.Commands.Create;
using Application.Features.AccountLearningPaths.Commands.Delete;
using Application.Features.AccountLearningPaths.Commands.Update;
using Application.Features.AccountLearningPaths.Queries.GetById;
using Application.Features.AccountLearningPaths.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.AccountLearningPaths.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<AccountLearningPath, CreateAccountLearningPathCommand>().ReverseMap();
        CreateMap<AccountLearningPath, CreatedAccountLearningPathResponse>().ReverseMap();
        CreateMap<AccountLearningPath, UpdateAccountLearningPathCommand>().ReverseMap();
        CreateMap<AccountLearningPath, UpdatedAccountLearningPathResponse>().ReverseMap();
        CreateMap<AccountLearningPath, DeleteAccountLearningPathCommand>().ReverseMap();
        CreateMap<AccountLearningPath, DeletedAccountLearningPathResponse>().ReverseMap();
        CreateMap<AccountLearningPath, GetByIdAccountLearningPathResponse>().ReverseMap();
        CreateMap<AccountLearningPath, GetListAccountLearningPathListItemDto>().ReverseMap();
        CreateMap<IPaginate<AccountLearningPath>, GetListResponse<GetListAccountLearningPathListItemDto>>().ReverseMap();
    }
}
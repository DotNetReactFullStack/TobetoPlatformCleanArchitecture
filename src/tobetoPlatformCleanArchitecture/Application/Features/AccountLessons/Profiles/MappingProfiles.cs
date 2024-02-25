using Application.Features.AccountLessons.Commands.Create;
using Application.Features.AccountLessons.Commands.Delete;
using Application.Features.AccountLessons.Commands.Update;
using Application.Features.AccountLessons.Queries.GetById;
using Application.Features.AccountLessons.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;
using Application.Features.AccountLessons.Queries.GetListByAccountIdAndLessonId;
using Application.Features.AccountLessons.Commands.Update.UpdateAccountLessonIsComplete;
using Application.Features.AccountLessons.Queries.GetListByAccountId;

namespace Application.Features.AccountLessons.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<AccountLesson, CreateAccountLessonCommand>().ReverseMap();
        CreateMap<AccountLesson, CreatedAccountLessonResponse>().ReverseMap();
        CreateMap<AccountLesson, UpdateAccountLessonCommand>().ReverseMap();
        CreateMap<AccountLesson, UpdatedAccountLessonResponse>().ReverseMap();
        CreateMap<AccountLesson, UpdateAccountLessonIsCompleteCommand>().ReverseMap();
        CreateMap<AccountLesson, DeleteAccountLessonCommand>().ReverseMap();
        CreateMap<AccountLesson, DeletedAccountLessonResponse>().ReverseMap();
        CreateMap<AccountLesson, GetByIdAccountLessonResponse>().ReverseMap();
        CreateMap<AccountLesson, GetListAccountLessonListItemDto>().ReverseMap();
        CreateMap<AccountLesson, GetByAccountIdAndLessonIdAccountLessonResponse>().ReverseMap();
        CreateMap<AccountLesson, GetListByAccountIdAccountLessonListItemDto>().ReverseMap();
        CreateMap<IPaginate<AccountLesson>, GetListResponse<GetListAccountLessonListItemDto>>().ReverseMap();
        CreateMap<IPaginate<AccountLesson>, GetListResponse<GetListByAccountIdAccountLessonListItemDto>>().ReverseMap();

    }
}
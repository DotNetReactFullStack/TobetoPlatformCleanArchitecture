using Application.Features.AccountLessons.Commands.Create;
using Application.Features.AccountLessons.Commands.Delete;
using Application.Features.AccountLessons.Commands.Update;
using Application.Features.AccountLessons.Queries.GetById;
using Application.Features.AccountLessons.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.AccountLessons.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<AccountLesson, CreateAccountLessonCommand>().ReverseMap();
        CreateMap<AccountLesson, CreatedAccountLessonResponse>().ReverseMap();
        CreateMap<AccountLesson, UpdateAccountLessonCommand>().ReverseMap();
        CreateMap<AccountLesson, UpdatedAccountLessonResponse>().ReverseMap();
        CreateMap<AccountLesson, DeleteAccountLessonCommand>().ReverseMap();
        CreateMap<AccountLesson, DeletedAccountLessonResponse>().ReverseMap();
        CreateMap<AccountLesson, GetByIdAccountLessonResponse>().ReverseMap();
        CreateMap<AccountLesson, GetListAccountLessonListItemDto>().ReverseMap();
        CreateMap<IPaginate<AccountLesson>, GetListResponse<GetListAccountLessonListItemDto>>().ReverseMap();
    }
}
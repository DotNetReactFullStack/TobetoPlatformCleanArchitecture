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
using Application.Features.AccountLessons.Queries.GetListByAccountIdAndLearningPathId;

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

        //--Deneme
        CreateMap<AccountLesson, GetListByAccountIdLearningPathAccountLessonListItemDto>()
     .ForMember(d => d.LearningPathId, opt => opt.MapFrom(al => al.Lesson.Course.CourseLearningPaths.FirstOrDefault().LearningPathId))

     .ForMember(d => d.LessonId, opt => opt.MapFrom(al => al.LessonId))
     .ForMember(d => d.AccountId, opt => opt.MapFrom(al => al.AccountId))
     .ForMember(d => d.Points, opt => opt.MapFrom(al => al.Points))
     .ForMember(d => d.IsComplete, opt => opt.MapFrom(al => al.IsComplete))
     .ForMember(d => d.LessonDuration, opt => opt.MapFrom(al => al.Lesson.Duration))
     .ForMember(d => d.CourseId, opt => opt.MapFrom(al => al.Lesson.CourseId))
     .ReverseMap();


        CreateMap<IPaginate<AccountLesson>, GetListResponse<GetListByAccountIdLearningPathAccountLessonListItemDto>>()
            .ForMember(d => d.Items, opt => opt.MapFrom(src => src.Items));


    }
}
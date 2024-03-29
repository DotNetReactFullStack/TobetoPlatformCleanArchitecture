using Application.Features.Lessons.Commands.Create;
using Application.Features.Lessons.Commands.Delete;
using Application.Features.Lessons.Commands.Update;
using Application.Features.Lessons.Queries.GetById;
using Application.Features.Lessons.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;
using Application.Features.Lessons.Queries.GetListByCourseId;
using Application.Features.Lessons.Commands.Update.UpdateLessonDuration;

namespace Application.Features.Lessons.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Lesson, CreateLessonCommand>().ReverseMap();
        CreateMap<Lesson, CreatedLessonResponse>().ReverseMap();
        CreateMap<Lesson, UpdateLessonCommand>().ReverseMap();
        CreateMap<Lesson, UpdatedLessonResponse>().ReverseMap();
        CreateMap<Lesson, UpdateLessonDurationCommand>().ReverseMap();
        CreateMap<Lesson, DeleteLessonCommand>().ReverseMap();
        CreateMap<Lesson, DeletedLessonResponse>().ReverseMap();
        CreateMap<Lesson, GetByIdLessonResponse>().ReverseMap();
        CreateMap<Lesson, GetListLessonListItemDto>().ReverseMap();
        CreateMap<Lesson, GetListByCourseIdLessonListItemDto>().ReverseMap();
        CreateMap<IPaginate<Lesson>, GetListResponse<GetListLessonListItemDto>>().ReverseMap();
        CreateMap<IPaginate<Lesson>, GetListResponse<GetListByCourseIdLessonListItemDto>>().ReverseMap();

    }
}
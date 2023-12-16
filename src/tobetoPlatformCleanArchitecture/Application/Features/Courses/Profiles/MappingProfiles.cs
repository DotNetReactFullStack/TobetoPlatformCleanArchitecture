using Application.Features.Courses.Commands.Create;
using Application.Features.Courses.Commands.Delete;
using Application.Features.Courses.Commands.Update;
using Application.Features.Courses.Queries.GetById;
using Application.Features.Courses.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.Courses.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Course, CreateCourseCommand>().ReverseMap();
        CreateMap<Course, CreatedCourseResponse>().ReverseMap();
        CreateMap<Course, UpdateCourseCommand>().ReverseMap();
        CreateMap<Course, UpdatedCourseResponse>().ReverseMap();
        CreateMap<Course, DeleteCourseCommand>().ReverseMap();
        CreateMap<Course, DeletedCourseResponse>().ReverseMap();
        CreateMap<Course, GetByIdCourseResponse>().ReverseMap();
        CreateMap<Course, GetListCourseListItemDto>().ReverseMap();
        CreateMap<IPaginate<Course>, GetListResponse<GetListCourseListItemDto>>().ReverseMap();
    }
}
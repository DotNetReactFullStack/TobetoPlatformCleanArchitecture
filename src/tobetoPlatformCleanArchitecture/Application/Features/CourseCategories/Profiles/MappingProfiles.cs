using Application.Features.CourseCategories.Commands.Create;
using Application.Features.CourseCategories.Commands.Delete;
using Application.Features.CourseCategories.Commands.Update;
using Application.Features.CourseCategories.Queries.GetById;
using Application.Features.CourseCategories.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.CourseCategories.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CourseCategory, CreateCourseCategoryCommand>().ReverseMap();
        CreateMap<CourseCategory, CreatedCourseCategoryResponse>().ReverseMap();
        CreateMap<CourseCategory, UpdateCourseCategoryCommand>().ReverseMap();
        CreateMap<CourseCategory, UpdatedCourseCategoryResponse>().ReverseMap();
        CreateMap<CourseCategory, DeleteCourseCategoryCommand>().ReverseMap();
        CreateMap<CourseCategory, DeletedCourseCategoryResponse>().ReverseMap();
        CreateMap<CourseCategory, GetByIdCourseCategoryResponse>().ReverseMap();
        CreateMap<CourseCategory, GetListCourseCategoryListItemDto>().ReverseMap();
        CreateMap<IPaginate<CourseCategory>, GetListResponse<GetListCourseCategoryListItemDto>>().ReverseMap();
    }
}
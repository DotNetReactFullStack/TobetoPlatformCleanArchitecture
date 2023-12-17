using Application.Features.Recourses.Commands.Create;
using Application.Features.Recourses.Commands.Delete;
using Application.Features.Recourses.Commands.Update;
using Application.Features.Recourses.Queries.GetById;
using Application.Features.Recourses.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.Recourses.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Recourse, CreateRecourseCommand>().ReverseMap();
        CreateMap<Recourse, CreatedRecourseResponse>().ReverseMap();
        CreateMap<Recourse, UpdateRecourseCommand>().ReverseMap();
        CreateMap<Recourse, UpdatedRecourseResponse>().ReverseMap();
        CreateMap<Recourse, DeleteRecourseCommand>().ReverseMap();
        CreateMap<Recourse, DeletedRecourseResponse>().ReverseMap();
        CreateMap<Recourse, GetByIdRecourseResponse>().ReverseMap();
        CreateMap<Recourse, GetListRecourseListItemDto>().ReverseMap();
        CreateMap<IPaginate<Recourse>, GetListResponse<GetListRecourseListItemDto>>().ReverseMap();
    }
}
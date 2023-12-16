using Application.Features.Classrooms.Commands.Create;
using Application.Features.Classrooms.Commands.Delete;
using Application.Features.Classrooms.Commands.Update;
using Application.Features.Classrooms.Queries.GetById;
using Application.Features.Classrooms.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.Classrooms.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Classroom, CreateClassroomCommand>().ReverseMap();
        CreateMap<Classroom, CreatedClassroomResponse>().ReverseMap();
        CreateMap<Classroom, UpdateClassroomCommand>().ReverseMap();
        CreateMap<Classroom, UpdatedClassroomResponse>().ReverseMap();
        CreateMap<Classroom, DeleteClassroomCommand>().ReverseMap();
        CreateMap<Classroom, DeletedClassroomResponse>().ReverseMap();
        CreateMap<Classroom, GetByIdClassroomResponse>().ReverseMap();
        CreateMap<Classroom, GetListClassroomListItemDto>().ReverseMap();
        CreateMap<IPaginate<Classroom>, GetListResponse<GetListClassroomListItemDto>>().ReverseMap();
    }
}
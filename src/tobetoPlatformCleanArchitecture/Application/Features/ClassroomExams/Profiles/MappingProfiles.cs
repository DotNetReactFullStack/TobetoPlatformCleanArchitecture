using Application.Features.ClassroomExams.Commands.Create;
using Application.Features.ClassroomExams.Commands.Delete;
using Application.Features.ClassroomExams.Commands.Update;
using Application.Features.ClassroomExams.Queries.GetById;
using Application.Features.ClassroomExams.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.ClassroomExams.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ClassroomExam, CreateClassroomExamCommand>().ReverseMap();
        CreateMap<ClassroomExam, CreatedClassroomExamResponse>().ReverseMap();
        CreateMap<ClassroomExam, UpdateClassroomExamCommand>().ReverseMap();
        CreateMap<ClassroomExam, UpdatedClassroomExamResponse>().ReverseMap();
        CreateMap<ClassroomExam, DeleteClassroomExamCommand>().ReverseMap();
        CreateMap<ClassroomExam, DeletedClassroomExamResponse>().ReverseMap();
        CreateMap<ClassroomExam, GetByIdClassroomExamResponse>().ReverseMap();
        CreateMap<ClassroomExam, GetListClassroomExamListItemDto>().ReverseMap();
        CreateMap<IPaginate<ClassroomExam>, GetListResponse<GetListClassroomExamListItemDto>>().ReverseMap();
    }
}
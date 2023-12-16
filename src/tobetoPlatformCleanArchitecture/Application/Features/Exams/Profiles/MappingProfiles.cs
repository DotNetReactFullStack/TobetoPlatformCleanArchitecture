using Application.Features.Exams.Commands.Create;
using Application.Features.Exams.Commands.Delete;
using Application.Features.Exams.Commands.Update;
using Application.Features.Exams.Queries.GetById;
using Application.Features.Exams.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.Exams.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Exam, CreateExamCommand>().ReverseMap();
        CreateMap<Exam, CreatedExamResponse>().ReverseMap();
        CreateMap<Exam, UpdateExamCommand>().ReverseMap();
        CreateMap<Exam, UpdatedExamResponse>().ReverseMap();
        CreateMap<Exam, DeleteExamCommand>().ReverseMap();
        CreateMap<Exam, DeletedExamResponse>().ReverseMap();
        CreateMap<Exam, GetByIdExamResponse>().ReverseMap();
        CreateMap<Exam, GetListExamListItemDto>().ReverseMap();
        CreateMap<IPaginate<Exam>, GetListResponse<GetListExamListItemDto>>().ReverseMap();
    }
}
using Application.Features.ExamQuestions.Commands.Create;
using Application.Features.ExamQuestions.Commands.Delete;
using Application.Features.ExamQuestions.Commands.Update;
using Application.Features.ExamQuestions.Queries.GetById;
using Application.Features.ExamQuestions.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.ExamQuestions.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ExamQuestion, CreateExamQuestionCommand>().ReverseMap();
        CreateMap<ExamQuestion, CreatedExamQuestionResponse>().ReverseMap();
        CreateMap<ExamQuestion, UpdateExamQuestionCommand>().ReverseMap();
        CreateMap<ExamQuestion, UpdatedExamQuestionResponse>().ReverseMap();
        CreateMap<ExamQuestion, DeleteExamQuestionCommand>().ReverseMap();
        CreateMap<ExamQuestion, DeletedExamQuestionResponse>().ReverseMap();
        CreateMap<ExamQuestion, GetByIdExamQuestionResponse>().ReverseMap();
        CreateMap<ExamQuestion, GetListExamQuestionListItemDto>().ReverseMap();
        CreateMap<IPaginate<ExamQuestion>, GetListResponse<GetListExamQuestionListItemDto>>().ReverseMap();
    }
}
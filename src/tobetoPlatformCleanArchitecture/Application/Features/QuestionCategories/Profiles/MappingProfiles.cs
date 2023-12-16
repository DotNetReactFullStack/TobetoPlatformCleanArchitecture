using Application.Features.QuestionCategories.Commands.Create;
using Application.Features.QuestionCategories.Commands.Delete;
using Application.Features.QuestionCategories.Commands.Update;
using Application.Features.QuestionCategories.Queries.GetById;
using Application.Features.QuestionCategories.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.QuestionCategories.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<QuestionCategory, CreateQuestionCategoryCommand>().ReverseMap();
        CreateMap<QuestionCategory, CreatedQuestionCategoryResponse>().ReverseMap();
        CreateMap<QuestionCategory, UpdateQuestionCategoryCommand>().ReverseMap();
        CreateMap<QuestionCategory, UpdatedQuestionCategoryResponse>().ReverseMap();
        CreateMap<QuestionCategory, DeleteQuestionCategoryCommand>().ReverseMap();
        CreateMap<QuestionCategory, DeletedQuestionCategoryResponse>().ReverseMap();
        CreateMap<QuestionCategory, GetByIdQuestionCategoryResponse>().ReverseMap();
        CreateMap<QuestionCategory, GetListQuestionCategoryListItemDto>().ReverseMap();
        CreateMap<IPaginate<QuestionCategory>, GetListResponse<GetListQuestionCategoryListItemDto>>().ReverseMap();
    }
}
using Application.Features.LearningPathCategories.Commands.Create;
using Application.Features.LearningPathCategories.Commands.Delete;
using Application.Features.LearningPathCategories.Commands.Update;
using Application.Features.LearningPathCategories.Queries.GetById;
using Application.Features.LearningPathCategories.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.LearningPathCategories.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<LearningPathCategory, CreateLearningPathCategoryCommand>().ReverseMap();
        CreateMap<LearningPathCategory, CreatedLearningPathCategoryResponse>().ReverseMap();
        CreateMap<LearningPathCategory, UpdateLearningPathCategoryCommand>().ReverseMap();
        CreateMap<LearningPathCategory, UpdatedLearningPathCategoryResponse>().ReverseMap();
        CreateMap<LearningPathCategory, DeleteLearningPathCategoryCommand>().ReverseMap();
        CreateMap<LearningPathCategory, DeletedLearningPathCategoryResponse>().ReverseMap();
        CreateMap<LearningPathCategory, GetByIdLearningPathCategoryResponse>().ReverseMap();
        CreateMap<LearningPathCategory, GetListLearningPathCategoryListItemDto>().ReverseMap();
        CreateMap<IPaginate<LearningPathCategory>, GetListResponse<GetListLearningPathCategoryListItemDto>>().ReverseMap();
    }
}
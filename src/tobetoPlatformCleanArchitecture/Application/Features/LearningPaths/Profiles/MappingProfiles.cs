using Application.Features.LearningPaths.Commands.Create;
using Application.Features.LearningPaths.Commands.Delete;
using Application.Features.LearningPaths.Commands.Update;
using Application.Features.LearningPaths.Queries.GetById;
using Application.Features.LearningPaths.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.LearningPaths.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<LearningPath, CreateLearningPathCommand>().ReverseMap();
        CreateMap<LearningPath, CreatedLearningPathResponse>().ReverseMap();
        CreateMap<LearningPath, UpdateLearningPathCommand>().ReverseMap();
        CreateMap<LearningPath, UpdatedLearningPathResponse>().ReverseMap();
        CreateMap<LearningPath, DeleteLearningPathCommand>().ReverseMap();
        CreateMap<LearningPath, DeletedLearningPathResponse>().ReverseMap();
        CreateMap<LearningPath, GetByIdLearningPathResponse>().ReverseMap();
        CreateMap<LearningPath, GetListLearningPathListItemDto>().ReverseMap();
        CreateMap<IPaginate<LearningPath>, GetListResponse<GetListLearningPathListItemDto>>().ReverseMap();
    }
}
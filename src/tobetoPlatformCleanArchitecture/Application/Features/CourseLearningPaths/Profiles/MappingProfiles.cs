using Application.Features.CourseLearningPaths.Commands.Create;
using Application.Features.CourseLearningPaths.Commands.Delete;
using Application.Features.CourseLearningPaths.Commands.Update;
using Application.Features.CourseLearningPaths.Queries.GetById;
using Application.Features.CourseLearningPaths.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.CourseLearningPaths.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CourseLearningPath, CreateCourseLearningPathCommand>().ReverseMap();
        CreateMap<CourseLearningPath, CreatedCourseLearningPathResponse>().ReverseMap();
        CreateMap<CourseLearningPath, UpdateCourseLearningPathCommand>().ReverseMap();
        CreateMap<CourseLearningPath, UpdatedCourseLearningPathResponse>().ReverseMap();
        CreateMap<CourseLearningPath, DeleteCourseLearningPathCommand>().ReverseMap();
        CreateMap<CourseLearningPath, DeletedCourseLearningPathResponse>().ReverseMap();
        CreateMap<CourseLearningPath, GetByIdCourseLearningPathResponse>().ReverseMap();
        CreateMap<CourseLearningPath, GetListCourseLearningPathListItemDto>().ReverseMap();
        CreateMap<IPaginate<CourseLearningPath>, GetListResponse<GetListCourseLearningPathListItemDto>>().ReverseMap();
    }
}
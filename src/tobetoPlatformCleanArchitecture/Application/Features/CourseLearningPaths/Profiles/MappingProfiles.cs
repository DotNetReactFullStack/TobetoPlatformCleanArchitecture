using Application.Features.CourseLearningPaths.Commands.Create;
using Application.Features.CourseLearningPaths.Commands.Delete;
using Application.Features.CourseLearningPaths.Commands.Update;
using Application.Features.CourseLearningPaths.Queries.GetById;
using Application.Features.CourseLearningPaths.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;
using Application.Features.CourseLearningPaths.Queries.GetListByLearningPathId;

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
        CreateMap<CourseLearningPath, GetListByLearningPathIdCourseLearningPathListItemDto>()
            .ForMember(destinationMember: d => d.LearningPathId,
            memberOptions: opt => opt.MapFrom(alp => alp.LearningPathId))
            .ForMember(destinationMember: d => d.CourseCategoryId,
            memberOptions: opt => opt.MapFrom(alp => alp.Course.CourseCategoryId))
            .ForMember(destinationMember: d => d.CourseName,
            memberOptions: opt => opt.MapFrom(alp => alp.Course.Name))
            .ForMember(destinationMember: d => d.TotalDuration,
            memberOptions: opt => opt.MapFrom(alp => alp.Course.TotalDuration))
            .ForMember(destinationMember: d => d.Priority,
            memberOptions: opt => opt.MapFrom(alp => alp.Course.Priority))
            .ForMember(destinationMember: d => d.IsActive,
            memberOptions: opt => opt.MapFrom(alp => alp.Course.IsActive))
            .ReverseMap();
        CreateMap<IPaginate<CourseLearningPath>, GetListResponse<GetListCourseLearningPathListItemDto>>().ReverseMap();
        CreateMap<IPaginate<CourseLearningPath>, GetListResponse<GetListByLearningPathIdCourseLearningPathListItemDto>>().ReverseMap();
    }
}
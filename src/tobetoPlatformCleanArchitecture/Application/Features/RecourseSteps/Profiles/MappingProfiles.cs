using Application.Features.RecourseSteps.Commands.Create;
using Application.Features.RecourseSteps.Commands.Delete;
using Application.Features.RecourseSteps.Commands.Update;
using Application.Features.RecourseSteps.Queries.GetById;
using Application.Features.RecourseSteps.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.RecourseSteps.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<RecourseStep, CreateRecourseStepCommand>().ReverseMap();
        CreateMap<RecourseStep, CreatedRecourseStepResponse>().ReverseMap();
        CreateMap<RecourseStep, UpdateRecourseStepCommand>().ReverseMap();
        CreateMap<RecourseStep, UpdatedRecourseStepResponse>().ReverseMap();
        CreateMap<RecourseStep, DeleteRecourseStepCommand>().ReverseMap();
        CreateMap<RecourseStep, DeletedRecourseStepResponse>().ReverseMap();
        CreateMap<RecourseStep, GetByIdRecourseStepResponse>().ReverseMap();
        CreateMap<RecourseStep, GetListRecourseStepListItemDto>().ReverseMap();
        CreateMap<IPaginate<RecourseStep>, GetListResponse<GetListRecourseStepListItemDto>>().ReverseMap();
    }
}
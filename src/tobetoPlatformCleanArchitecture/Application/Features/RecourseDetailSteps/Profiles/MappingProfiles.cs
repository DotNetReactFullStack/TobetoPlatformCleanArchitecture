using Application.Features.RecourseDetailSteps.Commands.Create;
using Application.Features.RecourseDetailSteps.Commands.Delete;
using Application.Features.RecourseDetailSteps.Commands.Update;
using Application.Features.RecourseDetailSteps.Queries.GetById;
using Application.Features.RecourseDetailSteps.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.RecourseDetailSteps.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<RecourseDetailStep, CreateRecourseDetailStepCommand>().ReverseMap();
        CreateMap<RecourseDetailStep, CreatedRecourseDetailStepResponse>().ReverseMap();
        CreateMap<RecourseDetailStep, UpdateRecourseDetailStepCommand>().ReverseMap();
        CreateMap<RecourseDetailStep, UpdatedRecourseDetailStepResponse>().ReverseMap();
        CreateMap<RecourseDetailStep, DeleteRecourseDetailStepCommand>().ReverseMap();
        CreateMap<RecourseDetailStep, DeletedRecourseDetailStepResponse>().ReverseMap();
        CreateMap<RecourseDetailStep, GetByIdRecourseDetailStepResponse>().ReverseMap();
        CreateMap<RecourseDetailStep, GetListRecourseDetailStepListItemDto>().ReverseMap();
        CreateMap<IPaginate<RecourseDetailStep>, GetListResponse<GetListRecourseDetailStepListItemDto>>().ReverseMap();
    }
}
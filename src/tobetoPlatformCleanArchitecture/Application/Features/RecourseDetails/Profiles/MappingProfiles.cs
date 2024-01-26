using Application.Features.RecourseDetails.Commands.Create;
using Application.Features.RecourseDetails.Commands.Delete;
using Application.Features.RecourseDetails.Commands.Update;
using Application.Features.RecourseDetails.Queries.GetById;
using Application.Features.RecourseDetails.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.RecourseDetails.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<RecourseDetail, CreateRecourseDetailCommand>().ReverseMap();
        CreateMap<RecourseDetail, CreatedRecourseDetailResponse>().ReverseMap();
        CreateMap<RecourseDetail, UpdateRecourseDetailCommand>().ReverseMap();
        CreateMap<RecourseDetail, UpdatedRecourseDetailResponse>().ReverseMap();
        CreateMap<RecourseDetail, DeleteRecourseDetailCommand>().ReverseMap();
        CreateMap<RecourseDetail, DeletedRecourseDetailResponse>().ReverseMap();
        CreateMap<RecourseDetail, GetByIdRecourseDetailResponse>().ReverseMap();
        CreateMap<RecourseDetail, GetListRecourseDetailListItemDto>().ReverseMap();
        CreateMap<IPaginate<RecourseDetail>, GetListResponse<GetListRecourseDetailListItemDto>>().ReverseMap();
    }
}
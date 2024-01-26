using Application.Features.Images.Commands.Create;
using Application.Features.Images.Commands.Delete;
using Application.Features.Images.Commands.Update;
using Application.Features.Images.Queries.GetById;
using Application.Features.Images.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.Images.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Image, CreateImageCommand>().ReverseMap();
        CreateMap<Image, CreatedImageResponse>().ReverseMap();
        CreateMap<Image, UpdateImageCommand>().ReverseMap();
        CreateMap<Image, UpdatedImageResponse>().ReverseMap();
        CreateMap<Image, DeleteImageCommand>().ReverseMap();
        CreateMap<Image, DeletedImageResponse>().ReverseMap();
        CreateMap<Image, GetByIdImageResponse>().ReverseMap();
        CreateMap<Image, GetListImageListItemDto>().ReverseMap();
        CreateMap<IPaginate<Image>, GetListResponse<GetListImageListItemDto>>().ReverseMap();
    }
}
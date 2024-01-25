using Application.Features.ImageExtensions.Commands.Create;
using Application.Features.ImageExtensions.Commands.Delete;
using Application.Features.ImageExtensions.Commands.Update;
using Application.Features.ImageExtensions.Queries.GetById;
using Application.Features.ImageExtensions.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.ImageExtensions.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ImageExtension, CreateImageExtensionCommand>().ReverseMap();
        CreateMap<ImageExtension, CreatedImageExtensionResponse>().ReverseMap();
        CreateMap<ImageExtension, UpdateImageExtensionCommand>().ReverseMap();
        CreateMap<ImageExtension, UpdatedImageExtensionResponse>().ReverseMap();
        CreateMap<ImageExtension, DeleteImageExtensionCommand>().ReverseMap();
        CreateMap<ImageExtension, DeletedImageExtensionResponse>().ReverseMap();
        CreateMap<ImageExtension, GetByIdImageExtensionResponse>().ReverseMap();
        CreateMap<ImageExtension, GetListImageExtensionListItemDto>().ReverseMap();
        CreateMap<IPaginate<ImageExtension>, GetListResponse<GetListImageExtensionListItemDto>>().ReverseMap();
    }
}
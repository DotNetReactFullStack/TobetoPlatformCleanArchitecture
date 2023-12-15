using Application.Features.ForeignLanguages.Commands.Create;
using Application.Features.ForeignLanguages.Commands.Delete;
using Application.Features.ForeignLanguages.Commands.Update;
using Application.Features.ForeignLanguages.Queries.GetById;
using Application.Features.ForeignLanguages.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.ForeignLanguages.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ForeignLanguage, CreateForeignLanguageCommand>().ReverseMap();
        CreateMap<ForeignLanguage, CreatedForeignLanguageResponse>().ReverseMap();
        CreateMap<ForeignLanguage, UpdateForeignLanguageCommand>().ReverseMap();
        CreateMap<ForeignLanguage, UpdatedForeignLanguageResponse>().ReverseMap();
        CreateMap<ForeignLanguage, DeleteForeignLanguageCommand>().ReverseMap();
        CreateMap<ForeignLanguage, DeletedForeignLanguageResponse>().ReverseMap();
        CreateMap<ForeignLanguage, GetByIdForeignLanguageResponse>().ReverseMap();
        CreateMap<ForeignLanguage, GetListForeignLanguageListItemDto>().ReverseMap();
        CreateMap<IPaginate<ForeignLanguage>, GetListResponse<GetListForeignLanguageListItemDto>>().ReverseMap();
    }
}
using Application.Features.ForeignLanguageLevels.Commands.Create;
using Application.Features.ForeignLanguageLevels.Commands.Delete;
using Application.Features.ForeignLanguageLevels.Commands.Update;
using Application.Features.ForeignLanguageLevels.Queries.GetById;
using Application.Features.ForeignLanguageLevels.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.ForeignLanguageLevels.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ForeignLanguageLevel, CreateForeignLanguageLevelCommand>().ReverseMap();
        CreateMap<ForeignLanguageLevel, CreatedForeignLanguageLevelResponse>().ReverseMap();
        CreateMap<ForeignLanguageLevel, UpdateForeignLanguageLevelCommand>().ReverseMap();
        CreateMap<ForeignLanguageLevel, UpdatedForeignLanguageLevelResponse>().ReverseMap();
        CreateMap<ForeignLanguageLevel, DeleteForeignLanguageLevelCommand>().ReverseMap();
        CreateMap<ForeignLanguageLevel, DeletedForeignLanguageLevelResponse>().ReverseMap();
        CreateMap<ForeignLanguageLevel, GetByIdForeignLanguageLevelResponse>().ReverseMap();
        CreateMap<ForeignLanguageLevel, GetListForeignLanguageLevelListItemDto>().ReverseMap();
        CreateMap<IPaginate<ForeignLanguageLevel>, GetListResponse<GetListForeignLanguageLevelListItemDto>>().ReverseMap();
    }
}
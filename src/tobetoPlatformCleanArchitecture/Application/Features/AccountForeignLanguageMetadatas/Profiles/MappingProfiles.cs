using Application.Features.AccountForeignLanguageMetadatas.Commands.Create;
using Application.Features.AccountForeignLanguageMetadatas.Commands.Delete;
using Application.Features.AccountForeignLanguageMetadatas.Commands.Update;
using Application.Features.AccountForeignLanguageMetadatas.Queries.GetById;
using Application.Features.AccountForeignLanguageMetadatas.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;
using Application.Features.AccountForeignLanguageMetadatas.Queries.GetListByAccountId;
using Application.Features.AccountCapabilities.Queries.GetListByAccountId;

namespace Application.Features.AccountForeignLanguageMetadatas.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<AccountForeignLanguageMetadata, CreateAccountForeignLanguageMetadataCommand>().ReverseMap();
        CreateMap<AccountForeignLanguageMetadata, CreatedAccountForeignLanguageMetadataResponse>().ReverseMap();
        CreateMap<AccountForeignLanguageMetadata, UpdateAccountForeignLanguageMetadataCommand>().ReverseMap();
        CreateMap<AccountForeignLanguageMetadata, UpdatedAccountForeignLanguageMetadataResponse>().ReverseMap();
        CreateMap<AccountForeignLanguageMetadata, DeleteAccountForeignLanguageMetadataCommand>().ReverseMap();
        CreateMap<AccountForeignLanguageMetadata, DeletedAccountForeignLanguageMetadataResponse>().ReverseMap();
        CreateMap<AccountForeignLanguageMetadata, GetByIdAccountForeignLanguageMetadataResponse>().ReverseMap();
        CreateMap<AccountForeignLanguageMetadata, GetByIdAccountForeignLanguageMetadataResponse>().ReverseMap();
        CreateMap<AccountForeignLanguageMetadata, GetListByAccountIdAccountForeingLanguageMetaDataItemDto>().ReverseMap();
        //CreateMap<AccountForeignLanguageMetadata, GetListByAccountIdAccountForeingLanguageMetaDataItemDto>()
        //    .ForMember(destinationMember: d => d.ForeignLanguageLevelName,
        //    memberOptions: opt => opt.MapFrom(fl => fl.ForeignLanguageLevel.Name))
        //    .ForMember(destinationMember: d => d.ForeingLanguageName,
        //    memberOptions: opt => opt.MapFrom(fl => fl.ForeignLanguage.Name)).ReverseMap();
        CreateMap<IPaginate<AccountForeignLanguageMetadata>, GetListResponse<GetListAccountForeignLanguageMetadataListItemDto>>().ReverseMap();
        CreateMap<IPaginate<AccountForeignLanguageMetadata>, GetListResponse<GetListByAccountIdAccountForeingLanguageMetaDataItemDto>>().ReverseMap();
        
        
    }
}
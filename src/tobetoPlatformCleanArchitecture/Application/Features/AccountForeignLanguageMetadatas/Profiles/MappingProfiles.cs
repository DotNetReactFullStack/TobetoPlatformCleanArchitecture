using Application.Features.AccountForeignLanguageMetadatas.Commands.Create;
using Application.Features.AccountForeignLanguageMetadatas.Commands.Delete;
using Application.Features.AccountForeignLanguageMetadatas.Commands.Update;
using Application.Features.AccountForeignLanguageMetadatas.Queries.GetById;
using Application.Features.AccountForeignLanguageMetadatas.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

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
        CreateMap<AccountForeignLanguageMetadata, GetListAccountForeignLanguageMetadataListItemDto>().ReverseMap();
        CreateMap<IPaginate<AccountForeignLanguageMetadata>, GetListResponse<GetListAccountForeignLanguageMetadataListItemDto>>().ReverseMap();
    }
}
using Application.Features.AccountCollageMetadatas.Commands.Create;
using Application.Features.AccountCollageMetadatas.Commands.Delete;
using Application.Features.AccountCollageMetadatas.Commands.Update;
using Application.Features.AccountCollageMetadatas.Queries.GetById;
using Application.Features.AccountCollageMetadatas.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.AccountCollageMetadatas.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<AccountCollageMetadata, CreateAccountCollageMetadataCommand>().ReverseMap();
        CreateMap<AccountCollageMetadata, CreatedAccountCollageMetadataResponse>().ReverseMap();
        CreateMap<AccountCollageMetadata, UpdateAccountCollageMetadataCommand>().ReverseMap();
        CreateMap<AccountCollageMetadata, UpdatedAccountCollageMetadataResponse>().ReverseMap();
        CreateMap<AccountCollageMetadata, DeleteAccountCollageMetadataCommand>().ReverseMap();
        CreateMap<AccountCollageMetadata, DeletedAccountCollageMetadataResponse>().ReverseMap();
        CreateMap<AccountCollageMetadata, GetByIdAccountCollageMetadataResponse>().ReverseMap();
        CreateMap<AccountCollageMetadata, GetListAccountCollageMetadataListItemDto>().ReverseMap();
        CreateMap<IPaginate<AccountCollageMetadata>, GetListResponse<GetListAccountCollageMetadataListItemDto>>().ReverseMap();
    }
}
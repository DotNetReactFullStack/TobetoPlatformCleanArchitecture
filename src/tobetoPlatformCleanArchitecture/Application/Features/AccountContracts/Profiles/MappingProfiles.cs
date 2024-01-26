using Application.Features.AccountContracts.Commands.Create;
using Application.Features.AccountContracts.Commands.Delete;
using Application.Features.AccountContracts.Commands.Update;
using Application.Features.AccountContracts.Queries.GetById;
using Application.Features.AccountContracts.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.AccountContracts.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<AccountContract, CreateAccountContractCommand>().ReverseMap();
        CreateMap<AccountContract, CreatedAccountContractResponse>().ReverseMap();
        CreateMap<AccountContract, UpdateAccountContractCommand>().ReverseMap();
        CreateMap<AccountContract, UpdatedAccountContractResponse>().ReverseMap();
        CreateMap<AccountContract, DeleteAccountContractCommand>().ReverseMap();
        CreateMap<AccountContract, DeletedAccountContractResponse>().ReverseMap();
        CreateMap<AccountContract, GetByIdAccountContractResponse>().ReverseMap();
        CreateMap<AccountContract, GetListAccountContractListItemDto>().ReverseMap();
        CreateMap<IPaginate<AccountContract>, GetListResponse<GetListAccountContractListItemDto>>().ReverseMap();
    }
}
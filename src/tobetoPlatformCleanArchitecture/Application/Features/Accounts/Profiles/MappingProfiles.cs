using Application.Features.Accounts.Commands.Create;
using Application.Features.Accounts.Commands.Delete;
using Application.Features.Accounts.Commands.Update;
using Application.Features.Accounts.Queries.GetById;
using Application.Features.Accounts.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.Accounts.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Account, CreateAccountCommand>().ReverseMap();
        CreateMap<Account, CreatedAccountResponse>().ReverseMap();
        CreateMap<Account, UpdateAccountCommand>().ReverseMap();
        CreateMap<Account, UpdatedAccountResponse>().ReverseMap();
        CreateMap<Account, DeleteAccountCommand>().ReverseMap();
        CreateMap<Account, DeletedAccountResponse>().ReverseMap();
        CreateMap<Account, GetByIdAccountResponse>().ReverseMap();
        CreateMap<Account, GetListAccountListItemDto>().ReverseMap();
        CreateMap<IPaginate<Account>, GetListResponse<GetListAccountListItemDto>>().ReverseMap();
    }
}
using Application.Features.Accounts.Commands.Create;
using Application.Features.Accounts.Commands.Delete;
using Application.Features.Accounts.Commands.Update;
using Application.Features.Accounts.Queries.GetById;
using Application.Features.Accounts.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;
using Application.Features.Accounts.Queries.GetByUserId;
using Core.Security.Entities;
using Application.Features.Accounts.Commands.Update.UpdateAccountInformation;

namespace Application.Features.Accounts.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Account, CreateAccountCommand>().ReverseMap();
        CreateMap<Account, CreatedAccountResponse>().ReverseMap();
        CreateMap<Account, UpdateAccountCommand>().ReverseMap();
        CreateMap<Account, UpdateAccountInformationCommand>().ReverseMap();
        CreateMap<Account, UpdatedAccountResponse>().ReverseMap();
        CreateMap<Account, DeleteAccountCommand>().ReverseMap();
        CreateMap<Account, DeletedAccountResponse>().ReverseMap();
        CreateMap<Account, GetByIdAccountResponse>().ReverseMap();
        CreateMap<Account, GetByUserIdAccountResponse>().ReverseMap();
        CreateMap<User, GetByUserIdAccountResponse>().ReverseMap();
        CreateMap<Account, GetListAccountListItemDto>().ReverseMap();
        CreateMap<IPaginate<Account>, GetListResponse<GetListAccountListItemDto>>().ReverseMap();
    }
}
using Application.Features.AccountExamResults.Commands.Create;
using Application.Features.AccountExamResults.Commands.Delete;
using Application.Features.AccountExamResults.Commands.Update;
using Application.Features.AccountExamResults.Queries.GetById;
using Application.Features.AccountExamResults.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.AccountExamResults.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<AccountExamResult, CreateAccountExamResultCommand>().ReverseMap();
        CreateMap<AccountExamResult, CreatedAccountExamResultResponse>().ReverseMap();
        CreateMap<AccountExamResult, UpdateAccountExamResultCommand>().ReverseMap();
        CreateMap<AccountExamResult, UpdatedAccountExamResultResponse>().ReverseMap();
        CreateMap<AccountExamResult, DeleteAccountExamResultCommand>().ReverseMap();
        CreateMap<AccountExamResult, DeletedAccountExamResultResponse>().ReverseMap();
        CreateMap<AccountExamResult, GetByIdAccountExamResultResponse>().ReverseMap();
        CreateMap<AccountExamResult, GetListAccountExamResultListItemDto>().ReverseMap();
        CreateMap<IPaginate<AccountExamResult>, GetListResponse<GetListAccountExamResultListItemDto>>().ReverseMap();
    }
}
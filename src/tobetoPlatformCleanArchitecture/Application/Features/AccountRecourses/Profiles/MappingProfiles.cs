using Application.Features.AccountRecourses.Commands.Create;
using Application.Features.AccountRecourses.Commands.Delete;
using Application.Features.AccountRecourses.Commands.Update;
using Application.Features.AccountRecourses.Queries.GetById;
using Application.Features.AccountRecourses.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.AccountRecourses.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<AccountRecourse, CreateAccountRecourseCommand>().ReverseMap();
        CreateMap<AccountRecourse, CreatedAccountRecourseResponse>().ReverseMap();
        CreateMap<AccountRecourse, UpdateAccountRecourseCommand>().ReverseMap();
        CreateMap<AccountRecourse, UpdatedAccountRecourseResponse>().ReverseMap();
        CreateMap<AccountRecourse, DeleteAccountRecourseCommand>().ReverseMap();
        CreateMap<AccountRecourse, DeletedAccountRecourseResponse>().ReverseMap();
        CreateMap<AccountRecourse, GetByIdAccountRecourseResponse>().ReverseMap();
        CreateMap<AccountRecourse, GetListAccountRecourseListItemDto>().ReverseMap();
        CreateMap<IPaginate<AccountRecourse>, GetListResponse<GetListAccountRecourseListItemDto>>().ReverseMap();
    }
}
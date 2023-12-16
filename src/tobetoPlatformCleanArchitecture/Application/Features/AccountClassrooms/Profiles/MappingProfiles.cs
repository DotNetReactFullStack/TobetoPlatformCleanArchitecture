using Application.Features.AccountClassrooms.Commands.Create;
using Application.Features.AccountClassrooms.Commands.Delete;
using Application.Features.AccountClassrooms.Commands.Update;
using Application.Features.AccountClassrooms.Queries.GetById;
using Application.Features.AccountClassrooms.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.AccountClassrooms.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<AccountClassroom, CreateAccountClassroomCommand>().ReverseMap();
        CreateMap<AccountClassroom, CreatedAccountClassroomResponse>().ReverseMap();
        CreateMap<AccountClassroom, UpdateAccountClassroomCommand>().ReverseMap();
        CreateMap<AccountClassroom, UpdatedAccountClassroomResponse>().ReverseMap();
        CreateMap<AccountClassroom, DeleteAccountClassroomCommand>().ReverseMap();
        CreateMap<AccountClassroom, DeletedAccountClassroomResponse>().ReverseMap();
        CreateMap<AccountClassroom, GetByIdAccountClassroomResponse>().ReverseMap();
        CreateMap<AccountClassroom, GetListAccountClassroomListItemDto>().ReverseMap();
        CreateMap<IPaginate<AccountClassroom>, GetListResponse<GetListAccountClassroomListItemDto>>().ReverseMap();
    }
}
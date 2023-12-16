using Application.Features.AccountCourses.Commands.Create;
using Application.Features.AccountCourses.Commands.Delete;
using Application.Features.AccountCourses.Commands.Update;
using Application.Features.AccountCourses.Queries.GetById;
using Application.Features.AccountCourses.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.AccountCourses.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<AccountCourse, CreateAccountCourseCommand>().ReverseMap();
        CreateMap<AccountCourse, CreatedAccountCourseResponse>().ReverseMap();
        CreateMap<AccountCourse, UpdateAccountCourseCommand>().ReverseMap();
        CreateMap<AccountCourse, UpdatedAccountCourseResponse>().ReverseMap();
        CreateMap<AccountCourse, DeleteAccountCourseCommand>().ReverseMap();
        CreateMap<AccountCourse, DeletedAccountCourseResponse>().ReverseMap();
        CreateMap<AccountCourse, GetByIdAccountCourseResponse>().ReverseMap();
        CreateMap<AccountCourse, GetListAccountCourseListItemDto>().ReverseMap();
        CreateMap<IPaginate<AccountCourse>, GetListResponse<GetListAccountCourseListItemDto>>().ReverseMap();
    }
}
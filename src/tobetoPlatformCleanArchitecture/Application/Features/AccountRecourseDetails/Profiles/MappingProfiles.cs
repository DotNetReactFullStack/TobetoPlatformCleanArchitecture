using Application.Features.AccountRecourseDetails.Commands.Create;
using Application.Features.AccountRecourseDetails.Commands.Delete;
using Application.Features.AccountRecourseDetails.Commands.Update;
using Application.Features.AccountRecourseDetails.Queries.GetById;
using Application.Features.AccountRecourseDetails.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.AccountRecourseDetails.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<AccountRecourseDetail, CreateAccountRecourseDetailCommand>().ReverseMap();
        CreateMap<AccountRecourseDetail, CreatedAccountRecourseDetailResponse>().ReverseMap();
        CreateMap<AccountRecourseDetail, UpdateAccountRecourseDetailCommand>().ReverseMap();
        CreateMap<AccountRecourseDetail, UpdatedAccountRecourseDetailResponse>().ReverseMap();
        CreateMap<AccountRecourseDetail, DeleteAccountRecourseDetailCommand>().ReverseMap();
        CreateMap<AccountRecourseDetail, DeletedAccountRecourseDetailResponse>().ReverseMap();
        CreateMap<AccountRecourseDetail, GetByIdAccountRecourseDetailResponse>().ReverseMap();
        CreateMap<AccountRecourseDetail, GetListAccountRecourseDetailListItemDto>().ReverseMap();
        CreateMap<IPaginate<AccountRecourseDetail>, GetListResponse<GetListAccountRecourseDetailListItemDto>>().ReverseMap();
    }
}
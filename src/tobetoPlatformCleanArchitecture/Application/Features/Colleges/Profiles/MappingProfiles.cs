using Application.Features.Colleges.Commands.Create;
using Application.Features.Colleges.Commands.Delete;
using Application.Features.Colleges.Commands.Update;
using Application.Features.Colleges.Queries.GetById;
using Application.Features.Colleges.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.Colleges.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<College, CreateCollegeCommand>().ReverseMap();
        CreateMap<College, CreatedCollegeResponse>().ReverseMap();
        CreateMap<College, UpdateCollegeCommand>().ReverseMap();
        CreateMap<College, UpdatedCollegeResponse>().ReverseMap();
        CreateMap<College, DeleteCollegeCommand>().ReverseMap();
        CreateMap<College, DeletedCollegeResponse>().ReverseMap();
        CreateMap<College, GetByIdCollegeResponse>().ReverseMap();
        CreateMap<College, GetListCollegeListItemDto>().ReverseMap();
        CreateMap<IPaginate<College>, GetListResponse<GetListCollegeListItemDto>>().ReverseMap();
    }
}
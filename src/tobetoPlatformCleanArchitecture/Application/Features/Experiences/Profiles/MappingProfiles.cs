using Application.Features.Experiences.Commands.Create;
using Application.Features.Experiences.Commands.Delete;
using Application.Features.Experiences.Commands.Update;
using Application.Features.Experiences.Queries.GetById;
using Application.Features.Experiences.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.Experiences.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Experience, CreateExperienceCommand>().ReverseMap();
        CreateMap<Experience, CreatedExperienceResponse>().ReverseMap();
        CreateMap<Experience, UpdateExperienceCommand>().ReverseMap();
        CreateMap<Experience, UpdatedExperienceResponse>().ReverseMap();
        CreateMap<Experience, DeleteExperienceCommand>().ReverseMap();
        CreateMap<Experience, DeletedExperienceResponse>().ReverseMap();
        CreateMap<Experience, GetByIdExperienceResponse>().ReverseMap();
        CreateMap<Experience, GetListExperienceListItemDto>().ReverseMap();
        CreateMap<IPaginate<Experience>, GetListResponse<GetListExperienceListItemDto>>().ReverseMap();
    }
}
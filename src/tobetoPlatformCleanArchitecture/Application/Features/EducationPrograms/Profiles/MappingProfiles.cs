using Application.Features.EducationPrograms.Commands.Create;
using Application.Features.EducationPrograms.Commands.Delete;
using Application.Features.EducationPrograms.Commands.Update;
using Application.Features.EducationPrograms.Queries.GetById;
using Application.Features.EducationPrograms.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.EducationPrograms.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<EducationProgram, CreateEducationProgramCommand>().ReverseMap();
        CreateMap<EducationProgram, CreatedEducationProgramResponse>().ReverseMap();
        CreateMap<EducationProgram, UpdateEducationProgramCommand>().ReverseMap();
        CreateMap<EducationProgram, UpdatedEducationProgramResponse>().ReverseMap();
        CreateMap<EducationProgram, DeleteEducationProgramCommand>().ReverseMap();
        CreateMap<EducationProgram, DeletedEducationProgramResponse>().ReverseMap();
        CreateMap<EducationProgram, GetByIdEducationProgramResponse>().ReverseMap();
        CreateMap<EducationProgram, GetListEducationProgramListItemDto>().ReverseMap();
        CreateMap<IPaginate<EducationProgram>, GetListResponse<GetListEducationProgramListItemDto>>().ReverseMap();
    }
}
using Application.Features.AccountCollegeMetadatas.Commands.Create;
using Application.Features.AccountCollegeMetadatas.Commands.Delete;
using Application.Features.AccountCollegeMetadatas.Commands.Update;
using Application.Features.AccountCollegeMetadatas.Queries.GetById;
using Application.Features.AccountCollegeMetadatas.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;
using Application.Features.AccountCollegeMetadatas.Queries.GetListByAccountId;

namespace Application.Features.AccountCollegeMetadatas.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<AccountCollegeMetadata, CreateAccountCollegeMetadataCommand>().ReverseMap();
        CreateMap<AccountCollegeMetadata, CreatedAccountCollegeMetadataResponse>().ReverseMap();
        CreateMap<AccountCollegeMetadata, UpdateAccountCollegeMetadataCommand>().ReverseMap();
        CreateMap<AccountCollegeMetadata, UpdatedAccountCollegeMetadataResponse>().ReverseMap();
        CreateMap<AccountCollegeMetadata, DeleteAccountCollegeMetadataCommand>().ReverseMap();
        CreateMap<AccountCollegeMetadata, DeletedAccountCollegeMetadataResponse>().ReverseMap();
        CreateMap<AccountCollegeMetadata, GetByIdAccountCollegeMetadataResponse>().ReverseMap();
        CreateMap<AccountCollegeMetadata, GetListAccountCollegeMetadataListItemDto>().ReverseMap();
        CreateMap<AccountCollegeMetadata, GetListByAccountIdAccountCollegeMetadataListItemDto>()
            .ForMember(destinationMember: d => d.GraduationStatusName,
            memberOptions: opt => opt.MapFrom(acm => acm.GraduationStatus.Name))
            .ForMember(destinationMember: d => d.CollegeName,
            memberOptions: opt => opt.MapFrom(acm => acm.College.Name))
            .ForMember(destinationMember: d => d.EducationProgramName,
            memberOptions: opt => opt.MapFrom(acm => acm.EducationProgram.Name))
            .ReverseMap();
        CreateMap<IPaginate<AccountCollegeMetadata>, GetListResponse<GetListAccountCollegeMetadataListItemDto>>().ReverseMap();
        CreateMap<IPaginate<AccountCollegeMetadata>, GetListResponse<GetListByAccountIdAccountCollegeMetadataListItemDto>>().ReverseMap();
    }
}
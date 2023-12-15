using Application.Features.Certificates.Commands.Create;
using Application.Features.Certificates.Commands.Delete;
using Application.Features.Certificates.Commands.Update;
using Application.Features.Certificates.Queries.GetById;
using Application.Features.Certificates.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.Certificates.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Certificate, CreateCertificateCommand>().ReverseMap();
        CreateMap<Certificate, CreatedCertificateResponse>().ReverseMap();
        CreateMap<Certificate, UpdateCertificateCommand>().ReverseMap();
        CreateMap<Certificate, UpdatedCertificateResponse>().ReverseMap();
        CreateMap<Certificate, DeleteCertificateCommand>().ReverseMap();
        CreateMap<Certificate, DeletedCertificateResponse>().ReverseMap();
        CreateMap<Certificate, GetByIdCertificateResponse>().ReverseMap();
        CreateMap<Certificate, GetListCertificateListItemDto>().ReverseMap();
        CreateMap<IPaginate<Certificate>, GetListResponse<GetListCertificateListItemDto>>().ReverseMap();
    }
}
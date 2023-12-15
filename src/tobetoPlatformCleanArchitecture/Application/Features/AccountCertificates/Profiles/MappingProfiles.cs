using Application.Features.AccountCertificates.Commands.Create;
using Application.Features.AccountCertificates.Commands.Delete;
using Application.Features.AccountCertificates.Commands.Update;
using Application.Features.AccountCertificates.Queries.GetById;
using Application.Features.AccountCertificates.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.AccountCertificates.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<AccountCertificate, CreateAccountCertificateCommand>().ReverseMap();
        CreateMap<AccountCertificate, CreatedAccountCertificateResponse>().ReverseMap();
        CreateMap<AccountCertificate, UpdateAccountCertificateCommand>().ReverseMap();
        CreateMap<AccountCertificate, UpdatedAccountCertificateResponse>().ReverseMap();
        CreateMap<AccountCertificate, DeleteAccountCertificateCommand>().ReverseMap();
        CreateMap<AccountCertificate, DeletedAccountCertificateResponse>().ReverseMap();
        CreateMap<AccountCertificate, GetByIdAccountCertificateResponse>().ReverseMap();
        CreateMap<AccountCertificate, GetListAccountCertificateListItemDto>().ReverseMap();
        CreateMap<IPaginate<AccountCertificate>, GetListResponse<GetListAccountCertificateListItemDto>>().ReverseMap();
    }
}
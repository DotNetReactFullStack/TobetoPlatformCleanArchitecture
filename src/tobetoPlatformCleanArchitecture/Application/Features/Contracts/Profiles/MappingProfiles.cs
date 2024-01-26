using Application.Features.Contracts.Commands.Create;
using Application.Features.Contracts.Commands.Delete;
using Application.Features.Contracts.Commands.Update;
using Application.Features.Contracts.Queries.GetById;
using Application.Features.Contracts.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.Contracts.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Contract, CreateContractCommand>().ReverseMap();
        CreateMap<Contract, CreatedContractResponse>().ReverseMap();
        CreateMap<Contract, UpdateContractCommand>().ReverseMap();
        CreateMap<Contract, UpdatedContractResponse>().ReverseMap();
        CreateMap<Contract, DeleteContractCommand>().ReverseMap();
        CreateMap<Contract, DeletedContractResponse>().ReverseMap();
        CreateMap<Contract, GetByIdContractResponse>().ReverseMap();
        CreateMap<Contract, GetListContractListItemDto>().ReverseMap();
        CreateMap<IPaginate<Contract>, GetListResponse<GetListContractListItemDto>>().ReverseMap();
    }
}
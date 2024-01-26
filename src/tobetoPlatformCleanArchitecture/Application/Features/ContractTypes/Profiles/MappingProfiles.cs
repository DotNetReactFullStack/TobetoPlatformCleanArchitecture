using Application.Features.ContractTypes.Commands.Create;
using Application.Features.ContractTypes.Commands.Delete;
using Application.Features.ContractTypes.Commands.Update;
using Application.Features.ContractTypes.Queries.GetById;
using Application.Features.ContractTypes.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.ContractTypes.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ContractType, CreateContractTypeCommand>().ReverseMap();
        CreateMap<ContractType, CreatedContractTypeResponse>().ReverseMap();
        CreateMap<ContractType, UpdateContractTypeCommand>().ReverseMap();
        CreateMap<ContractType, UpdatedContractTypeResponse>().ReverseMap();
        CreateMap<ContractType, DeleteContractTypeCommand>().ReverseMap();
        CreateMap<ContractType, DeletedContractTypeResponse>().ReverseMap();
        CreateMap<ContractType, GetByIdContractTypeResponse>().ReverseMap();
        CreateMap<ContractType, GetListContractTypeListItemDto>().ReverseMap();
        CreateMap<IPaginate<ContractType>, GetListResponse<GetListContractTypeListItemDto>>().ReverseMap();
    }
}